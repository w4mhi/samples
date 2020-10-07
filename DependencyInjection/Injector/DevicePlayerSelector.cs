namespace DIMedia.Selector
{
    using DIMedia.DevicePlayer;
    using DIMedia.Media;
    using DIMedia.Player;

    public class DevicePlayerSelector : IDevicePlayerSelector
    {
        public IMediaPlayer GetDevicePlayer(MediaContent mediaContent)
        {
            switch (mediaContent.MediaType)
            {
                case MediaType.Tape:
                    return new MediaPlayer(new CasettePlayer(mediaContent));

                case MediaType.CDDisk:
                    return new MediaPlayer(new CDPlayer(mediaContent));

                case MediaType.DVDDisk:
                    return new MediaPlayer(new DVDPlayer(mediaContent));

                default:
                    return null;
            }
        }
    }
}
