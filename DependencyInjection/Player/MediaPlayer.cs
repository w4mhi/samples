namespace DIMedia.Player
{
    using DIMedia.DevicePlayer;

    public class MediaPlayer : IMediaPlayer
    {
        // this line could be uncommented in the case of constructor/method injection
        // private IDevicePlayer devicePlayer;

        // in case of constructor/method, the setter should be private
        public IDevicePlayer DevicePlayer { get; set; }

        public MediaPlayer()
        { }

        // with constructor
        public MediaPlayer(IDevicePlayer devicePlayer)
        {
            this.DevicePlayer = devicePlayer;
        }

        // with method
        public void Register(IDevicePlayer devicePlayer)
        {
            this.DevicePlayer = devicePlayer;
        }

        public void PlayMediaContent()
        {
            this.DevicePlayer.Play();
        }
    }
}
