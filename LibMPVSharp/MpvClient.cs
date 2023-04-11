using System.Runtime.InteropServices;

namespace LibMPVSharp;

public class MpvClient
{
    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_error_string(MpvError error);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_free(IntPtr data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_client_name(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern long mpv_client_id(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_create();

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_initialize(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_destroy(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_terminate_destroy(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_create_client(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_create_weak_client(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_load_config_file(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern long mpv_get_time_us(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_free_node_contents(IntPtr mpvNode);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_set_option(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format, IntPtr data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_set_option_string(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command(IntPtr mpvHandle, IntPtr strings);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command_node(IntPtr mpvHandle, IntPtr strings, IntPtr result);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command_ret(IntPtr mpvHandle, IntPtr strings, IntPtr node);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command_string(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string args);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command_async(IntPtr mpvHandle, ulong replayUserData, IntPtr strings);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_command_node_async(IntPtr mpvHandle, ulong replayUserData, IntPtr nodes);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_abort_async_command(IntPtr mpvHandle, ulong replayUserData);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_set_property(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format, IntPtr data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_set_property_string(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, [MarshalAs(UnmanagedType.LPUTF8Str)] string data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_del_property(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_set_property_async(IntPtr mpvHandle, ulong replayUserData, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format, IntPtr data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_get_property(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format, out IntPtr data);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_get_property_string(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_get_property_osd_string(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string name);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_get_property_async(IntPtr mpvHandle, ulong replayUserData, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_observe_property(IntPtr mpvHandle, ulong replayUserData, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, MpvFormat format);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern int mpv_unobserve_property(IntPtr mpvHandle, ulong registeredReplyUserData);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_event_name(MpvEventId eventId);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_event_to_node(IntPtr mpvNode, IntPtr mpvEvent);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_request_event(IntPtr mpvHandle, MpvEventId eventId, int enable);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_request_log_messages(IntPtr mpvHandle, [MarshalAs(UnmanagedType.LPUTF8Str)] string minLevel);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern IntPtr mpv_wait_event(IntPtr mpvHandle, double timeOut);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_wakeup(IntPtr mpvHandle);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    public delegate void WakeupCallbackFn(IntPtr param);
    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_set_wakeup_callback(IntPtr mpvHandle, [MarshalAs(UnmanagedType.FunctionPtr)] WakeupCallbackFn cb, IntPtr param);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_wait_async_requests(IntPtr mpvHandle);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern void mpv_hook_add(IntPtr mpvHandle, ulong replyUserData, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int priority);

    [DllImport("libmpv-2.dll", CallingConvention = CallingConvention.Cdecl)]
    public static extern MpvError mpv_hook_continue(IntPtr mpvHandle, ulong replyUserData, [MarshalAs(UnmanagedType.LPUTF8Str)] string name, int priority);
}