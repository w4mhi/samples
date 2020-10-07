namespace DIMedia.DevicePlayer
{
    using DIMedia.Media;
    using System;

    public class CDPlayer : DevicePlayer
    {
        private readonly MediaType mediaType = MediaType.CDDisk;

        public CDPlayer(MediaContent mediaContent) :
            base(mediaContent)
        {
            if (this.mediaType != mediaContent.MediaType)
            {
                throw new Exception($"{this.GetType().Name} cannot play {mediaContent.MediaType}.");
            }

            Console.WriteLine($"Loading {mediaContent.MediaType} in {this.GetType().Name}...");
        }
    }
}
