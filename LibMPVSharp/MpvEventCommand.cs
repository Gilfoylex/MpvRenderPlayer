using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public struct MpvEventCommand
{
    public MpvNode result;
}

