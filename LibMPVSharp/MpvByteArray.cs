using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Sequential)]
public class MpvByteArray
{
    public IntPtr data;
    public int size;
}
