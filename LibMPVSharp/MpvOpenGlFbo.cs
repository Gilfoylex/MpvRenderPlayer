using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvOpenGlFbo
{
    public int fbo;
    public int w;
    public int h;
    public int internal_format;
}
