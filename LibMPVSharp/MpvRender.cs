using System.Runtime.InteropServices;

namespace LibMPVSharp;

public class MpvRender
{
    public const string MpvRenderApiTypeOpenGl = "opengl";
    public const string MpvRenderApiTypeSw = "sw";

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_render_context_create(ref IntPtr mpvRenderContext, IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPArray)] MpvRenderParam[] renderParams);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_render_context_set_parameter(IntPtr mpvRenderContext, MpvRenderParam param);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_render_context_get_info(IntPtr mpvRenderContext, MpvRenderParam param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void MpvRenderUpdateFn(IntPtr param);
    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_render_context_set_update_callback(IntPtr mpvRenderContext, [MarshalAs(UnmanagedType.FunctionPtr)]MpvRenderUpdateFn callback, IntPtr param);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern ulong mpv_render_context_update(IntPtr mpvRenderContext);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_render_context_render(IntPtr mpvRenderContext, [MarshalAs(UnmanagedType.LPArray)] MpvRenderParam[] renderParams);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_render_context_report_swap(IntPtr mpvRenderContext);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_render_context_free(IntPtr mpvRenderContext);
}

