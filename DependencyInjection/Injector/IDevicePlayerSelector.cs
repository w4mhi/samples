namespace DIMedia.Selector
{
    using DIMedia.Media;
    using DIMedia.Player;

    public interface IDevicePlayerSelector
    {
        IMediaPlayer GetDevicePlayer(MediaContent mediaContent);
    }
}