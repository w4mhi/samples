using DIMedia.Media;
using System;

namespace DIMedia.DevicePlayer
{
    public abstract class DevicePlayer : IDevicePlayer
    {
        protected readonly MediaContent mediaContent;

        public DevicePlayer(MediaContent mediaContent)
        {
            this.mediaContent = mediaContent ?? throw new ArgumentNullException(nameof(mediaContent));
        }

        public virtual void Play()
        {
            Console.WriteLine($"Playing {mediaContent.Title} with {this.GetType().Name}.");

            foreach (string item in mediaContent.Content)
            {
                Console.WriteLine($"Playing {item}...");
            }
            
            Console.WriteLine($"Eject {mediaContent.MediaType}...");
            Console.WriteLine();
        }

        public virtual void Pause()
        {
            Console.WriteLine($"Pause.");
        }
    }
}
