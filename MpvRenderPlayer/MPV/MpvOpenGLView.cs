using Avalonia.Controls;
using Avalonia.OpenGL.Controls;
using Avalonia.OpenGL;
using Avalonia.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MpvRenderPlayer.MPV
{
    internal class MpvOpenGLView : OpenGlControlBase
    {
        private MpvPlayer _player { get; }
        public MpvOpenGLView(MpvPlayer player)
        {
            _player = player;
        }

        protected override void OnOpenGlInit(GlInterface gl)
        {
            _player.InitOpenGlContext(gl, UpdateCallBack);
        }

        private void UpdateCallBack(IntPtr obj)
        {
            Dispatcher.UIThread.Post(RequestNextFrameRendering, DispatcherPriority.Background);
        }

        protected override void OnOpenGlRender(GlInterface gl, int fb)
        {
            var dpiScale = 1D;
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel?.PlatformImpl != null)
            {
                dpiScale = topLevel.PlatformImpl.RenderScaling;
            }

            var width = (int)(Bounds.Width * dpiScale);
            var height = (int)(Bounds.Height * dpiScale);

            gl.Clear(GlConsts.GL_COLOR_BUFFER_BIT | GlConsts.GL_DEPTH_BUFFER_BIT | GlConsts.GL_STENCIL_BUFFER_BIT);
            gl.Viewport(0, 0, width, height);
            

            _player.Render(fb, width, height);
            //RequestNextFrameRendering();
        }
    }
}
