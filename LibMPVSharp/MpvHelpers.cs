using System.Runtime.InteropServices;
using System.Text;

namespace LibMPVSharp;

public class MpvHelpers
{
    public static string GetError(MpvError err) => ConvertFromUtf8(MpvClient.mpv_error_string(err));

    public static byte[] GetUtf8Bytes(string s) => Encoding.UTF8.GetBytes(s + "\0");

    public static string ConvertFromUtf8(IntPtr nativeUtf8)
    {
        var len = 0;

        while (Marshal.ReadByte(nativeUtf8, len) != 0)
            ++len;

        var buffer = new byte[len];
        Marshal.Copy(nativeUtf8, buffer, 0, buffer.Length);
        return Encoding.UTF8.GetString(buffer);
    }
}
