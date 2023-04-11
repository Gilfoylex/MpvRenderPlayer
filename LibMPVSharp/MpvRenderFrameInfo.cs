using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvRenderFrameInfo
{
    public ulong flags;
    public long target_time;
}