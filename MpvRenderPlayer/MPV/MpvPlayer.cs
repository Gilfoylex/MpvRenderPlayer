using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using Avalonia.OpenGL;
using Avalonia.Threading;
using LibMPVSharp;

namespace MpvRenderPlayer.MPV;

public class MpvPlayer
{
    private IntPtr _mpvHandle = IntPtr.Zero;
    private IntPtr _mpvGlHandle = IntPtr.Zero;
    private Thread? _mpvMessageThread;

    public MpvPlayer()
    {
        _mpvHandle = MpvClient.mpv_create();
        if (_mpvHandle == IntPtr.Zero)
            return;

        var error = MpvClient.mpv_set_option_string(_mpvHandle, "terminal", "yes");
        error = MpvClient.mpv_set_option_string(_mpvHandle, "msg-level", "all=v");

        error = MpvClient.mpv_initialize(_mpvHandle);
        if (error != MpvError.Success)
        {
            //Logger.TryGet(LogLevel.Warn, LogArea.Player)?.Log($"mpv_initialize failed, mpv_error is : {MpvHelpers.GetError(error)}");
            return;
        }

        error = MpvClient.mpv_set_option_string(_mpvHandle, "hwdec", "auto");
        
        MpvClient.mpv_set_wakeup_callback(_mpvHandle, WakeUpCallBack, IntPtr.Zero);
    }

    private bool bfirst;

    public void InitOpenGlContext(GlInterface gl, Action<IntPtr> updateCallBack)
    {
        if (bfirst)
        {
            return;
        }

        bfirst = true;

        using var strPtr = new ByteArrayPtr(MpvHelpers.GetUtf8Bytes(MpvRender.MpvRenderApiTypeOpenGl));
        var p1 = new MpvRenderParam()
        {
            type = MpvRenderParamType.ApiType,
            data = strPtr.InnerPtr
        };

        var initPrams = new MpvOpenGlInitParams()
        {
            get_proc_address = (ctx, name) => gl.GetProcAddress(name),
            get_proc_address_ctx = IntPtr.Zero
        };
        using var initPramsPtr = new StructurePtr<MpvOpenGlInitParams>(initPrams);
        var p2 = new MpvRenderParam()
        {
            type = MpvRenderParamType.OpenGlInitParams,
            data = initPramsPtr.InnerPtr
        };

        using var enablePtr = new StructurePtr<int>(1);
        var p3 = new MpvRenderParam()
        {
            type = MpvRenderParamType.AdvancedControl,
            data = enablePtr.InnerPtr
        };

        var p4 = new MpvRenderParam()
        {
            type = MpvRenderParamType.Invalid,
            data = IntPtr.Zero
        };

        var renderParams = new MpvRenderParam[]
        {
            p1, p2, p4,
        };

        var error = MpvRender.mpv_render_context_create(ref _mpvGlHandle, _mpvHandle, renderParams);
        if (error == MpvError.Success)
        {
            MpvRender.mpv_render_context_set_update_callback(_mpvGlHandle, updateCallBack.Invoke, IntPtr.Zero);
        }
        else
        {

        }
    }


    public void Render(int fb, int width, int height)
    {
        if (_mpvHandle == IntPtr.Zero || _mpvGlHandle == IntPtr.Zero)
            return;

        MpvOpenGlFbo glFbo = new()
        {
            fbo = fb, w = width, h = height, internal_format = 0
        };
        
        using var glFboPtr = new StructurePtr<MpvOpenGlFbo>(glFbo);
        var p1 = new MpvRenderParam()
        {
            type = MpvRenderParamType.OpenGlFbo,
            data = glFboPtr.InnerPtr
        };

        using var flipYPtr = new StructurePtr<int>(1);
        var p2 = new MpvRenderParam()
        {
            type = MpvRenderParamType.FlipY,
            data = flipYPtr.InnerPtr
        };
        
        var p3 = new MpvRenderParam()
        {
            type = MpvRenderParamType.Invalid,
            data = IntPtr.Zero
        };

        var renderParams = new MpvRenderParam[3]
        {
            p1, p2, p3
        };


        //var ret = MpvRender.mpv_render_context_update(_mpvGlHandle);
        //if ((ret & (ulong) MpvRenderUpdateFlag.Frame) > 0)
        {
            var error = MpvRender.mpv_render_context_render(_mpvGlHandle, renderParams);
            
            if (error != (int)MpvError.Success)
            {

            }
        }
    }

    public void Dispose()
    {
        //Stop();
        
        if (_mpvGlHandle != IntPtr.Zero)
            MpvRender.mpv_render_context_free(_mpvGlHandle);
        
        if (_mpvHandle != IntPtr.Zero)
            MpvClient.mpv_destroy(_mpvHandle);
    }

    private void WakeUpCallBack(IntPtr param)
    {
        Dispatcher.UIThread.Post(() =>
        {
            while (true)
            {
                var ptr = MpvClient.mpv_wait_event(_mpvHandle, 0);
                var mpvEvent = Marshal.PtrToStructure<MpvEvent>(ptr);
                if (mpvEvent.event_id is MpvEventId.None or MpvEventId.ShutDown)
                {
                    break;
                }
                else if (mpvEvent.event_id is MpvEventId.LogMessage)
                {
                    var data = Marshal.PtrToStructure<MpvLogMessage>(mpvEvent.data);
                    //Logger.TryGet(LogLevel.Info, LogArea.Player)?.Log($"mpv-log: {MpvHelpers.ConvertFromUtf8(data.level)}," +
                                                                      //$" {MpvHelpers.ConvertFromUtf8(data.text)}");
                }
                else
                {

                }
            }
        }, DispatcherPriority.Background);
    }

    public void PlayUrl(string url)
    {
        MpvCommand("loadfile", url, "replace");
    }

    private void MpvCommand(params string[] args)
    {
        if (_mpvHandle == IntPtr.Zero)
            return;

        var count = args.Length + 1;
        var pointers = new IntPtr[count];
        var rootPtr = Marshal.AllocHGlobal(IntPtr.Size * count);
        try
        {
            for (var i = 0; i < args.Length; i++)
            {
                var bytes = MpvHelpers.GetUtf8Bytes(args[i]);
                var ptr = Marshal.AllocHGlobal(bytes.Length);
                Marshal.Copy(bytes, 0, ptr, bytes.Length);
                pointers[i] = ptr;
            }

            Marshal.Copy(pointers, 0, rootPtr, count);
            var error = MpvClient.mpv_command(_mpvHandle, rootPtr);
            if (error != MpvError.Success)
            {
                var log = args.Aggregate("", (current, s) => current + s);
                //Logger.TryGet(LogLevel.Debug, LogArea.Player)?.Log($"mpv command error = {error}, {log} ");
            }
        }
        catch (Exception e)
        {
            //Logger.TryGet(LogLevel.Error, LogArea.Player)?.Log($"{e.Message}");
        }
        finally
        {
            foreach (var ptr in pointers)
            {
                Marshal.FreeHGlobal(ptr);
            }
            Marshal.FreeHGlobal(rootPtr);
        }
    }
}