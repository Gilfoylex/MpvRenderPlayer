namespace LibMPVSharp;

public enum MpvError
{
    Success = 0,
    EventQueueFull = -1,
    NoMem = -2,
    Uninitialized = -3,
    InvalidParameter = -4,
    OptionNotFound = -5,
    OptionFormat = -6,
    OptionError = -7,
    PropertyNotFound = -8,
    PropertyFormat = -9,
    PropertyUnavailable = -10,
    PropertyError = -11,
    Command = -12,
    LoadingFailed = -13,
    AudioInitFailed = -14,
    VideoInitFailed = -15,
    NothingToPlay = -16,
    UnknownFormat = -17,
    UnSupport = -18,
    NotImplement = -19,
    Generic = -20,
}