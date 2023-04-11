using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LibMPVSharp;

public class StructurePtr<T> : IDisposable
{
    public IntPtr InnerPtr { get; }

    public StructurePtr(T value)
    {
        InnerPtr = GenIntPtr(value);
    }

    private IntPtr GenIntPtr(T value)
    {
        var ptr = Marshal.AllocHGlobal(Marshal.SizeOf(value));
        try
        {
            Marshal.StructureToPtr(value!, ptr, false);
            return ptr;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            Marshal.FreeHGlobal(ptr);
            return IntPtr.Zero;
        }
    }

    public void Dispose()
    {
        if (InnerPtr != IntPtr.Zero)
            Marshal.FreeHGlobal(InnerPtr);
    }
}

