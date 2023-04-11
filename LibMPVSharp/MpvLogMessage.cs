using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvLogMessage
{
    public IntPtr prefix;
    public IntPtr level;
    public IntPtr text;
    public MpvLogLevel log_level;
}
