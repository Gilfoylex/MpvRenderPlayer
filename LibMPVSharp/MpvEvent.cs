using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvEvent
{
    public MpvEventId event_id;
    public MpvError error;
    public ulong reply_user_data;
    public IntPtr data;
}
