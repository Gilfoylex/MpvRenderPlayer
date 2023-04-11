using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvEventClientMessage
{
    public int num_args;
    public IntPtr args;
}
