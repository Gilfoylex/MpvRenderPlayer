using System.Runtime.InteropServices;

namespace LibMPVSharp;

[StructLayout(LayoutKind.Explicit, Size = 16)]
public struct MpvNode
{
    [FieldOffset(0)] public IntPtr str;
    [FieldOffset(0)] public int flag;
    [FieldOffset(0)] public long int64;
    [FieldOffset(0)] public double dbl;
    [FieldOffset(0)] public IntPtr list;
    [FieldOffset(0)] public IntPtr ba;
    [FieldOffset(8)] public MpvFormat format;
}