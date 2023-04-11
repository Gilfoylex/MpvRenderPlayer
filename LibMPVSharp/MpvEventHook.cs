using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvEventHook
{
    public IntPtr name;
    public ulong id;
}