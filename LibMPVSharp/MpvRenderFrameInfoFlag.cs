namespace LibMPVSharp;

[Flags]
public enum MpvRenderFrameInfoFlag
{
    Present = 1 << 0,
    Redraw = 1 << 1,
    Repeat = 1 << 2,
    Block = 1 << 3,
}
