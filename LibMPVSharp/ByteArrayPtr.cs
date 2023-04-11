using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LibMPVSharp;
public class ByteArrayPtr : IDisposable
{
    public IntPtr InnerPtr { get; }

    public ByteArrayPtr(byte[] bytes)
    {
        InnerPtr = GenIntPtr(bytes);
    }

    private IntPtr GenIntPtr(byte[] bytes)
    {
        var size = bytes.Length;
        if (size == 0)
        {
            return IntPtr.Zero;
        }

        var ptr = Marshal.AllocHGlobal(size);
        try
        {
            Marshal.Copy(bytes, 0, ptr, size);
            return ptr;
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
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
