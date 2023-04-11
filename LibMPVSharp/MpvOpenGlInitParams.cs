using System.Runtime.InteropServices;

namespace LibMPVSharp;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate IntPtr GetProcAddressFn(IntPtr ctx, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);
[StructLayout(LayoutKind.Sequential)]
public struct MpvOpenGlInitParams
{
    public GetProcAddressFn get_proc_address;
    public IntPtr get_proc_address_ctx;
}
