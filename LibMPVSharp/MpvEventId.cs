namespace LibMPVSharp;

public enum MpvEventId
{
    None = 0,
    ShutDown = 1,
    LogMessage = 2,
    GetPropertyReply = 3,
    SetPropertyReply = 4,
    CommandReply = 5,
    StartFile = 6,
    EndFile = 7,
    FileLoaded = 8,
    ClientMessage = 16,
    VideoReConfig = 17,
    AudioReConfig = 18,
    Seek = 20,
    PlayBackRestart = 21,
    PropertyChange = 22,
    QueueOverFlow = 24,
    Hook = 25,
}