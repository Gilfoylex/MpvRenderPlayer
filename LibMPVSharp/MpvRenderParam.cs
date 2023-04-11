using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvRenderParam
{
    public MpvRenderParamType type;
    public IntPtr data;
}
