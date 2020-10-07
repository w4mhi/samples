namespace DIMedia
{
    using DIMedia.DevicePlayer;
    using DIMedia.Media;
    using DIMedia.Player;
    using DIMedia.Selector;
    using System.Collections.Generic;

    class Program
    {
        static void Main()
        {
            MediaContent tapeContent = new MediaContent()
            {
                MediaType = MediaType.Tape,
                Title = "Oldies, but Goldies!",
                Content = new List<string>() {
                    "1 - Name - Old Song",
                    "2 - Name - Old Song",
                    "3 - Name - Old Song"
                },
            };

            MediaContent cdContent = new MediaContent()
            {
                MediaType = MediaType.CDDisk,
                Title = "Jazz",
                Content = new List<string>() {
                    "1 - Name - Jazz Song",
                    "2 - Name - Jazz Song",
                    "3 - Name - Jazz Song"
                },
            };

            MediaContent dvdContent = new MediaContent()
            {
                MediaType = MediaType.DVDDisk,
                Title = "Rock!",
                Content = new List<string>() {
                    "1 - Name - Rock Song",
                    "2 - Name - Rock Song",
                    "3 - Name - Rock Song"
                },
            };

            // using the injector class
            IDevicePlayerSelector playerSelector = new DevicePlayerSelector();

            // get the player by content
            IMediaPlayer mediaCasettePlayer = playerSelector.GetDevicePlayer(tapeContent);
            mediaCasettePlayer.PlayMediaContent();

            IMediaPlayer mediaCdPlayer = playerSelector.GetDevicePlayer(cdContent);
            mediaCdPlayer.PlayMediaContent();

            IMediaPlayer mediaDvdPlayer = playerSelector.GetDevicePlayer(dvdContent);
            mediaDvdPlayer.PlayMediaContent();

            // constructor injection
            CasettePlayer casettePlayer = new CasettePlayer(tapeContent);

            // registration
            IMediaPlayer mediaPlayer = new MediaPlayer(casettePlayer);
            mediaPlayer.PlayMediaContent();

            // method injection
            CDPlayer cdPlayer = new CDPlayer(cdContent);
            MediaPlayer anotherMediaPlayer = new MediaPlayer();
            // registration
            anotherMediaPlayer.Register(cdPlayer);
            anotherMediaPlayer.PlayMediaContent();

            // setter injection
            DVDPlayer dvdPlayer = new DVDPlayer(dvdContent);
            // registration
            MediaPlayer newMediaPlayer = new MediaPlayer()
            {
                DevicePlayer = dvdPlayer,
            };
            newMediaPlayer.PlayMediaContent();
        }
    }
}
