namespace DIMedia.Media
{
    using System.Collections.Generic;

    public class MediaContent
    {
        public MediaType MediaType { get; set; }
        public object Title { get; internal set; }
        public List<string> Content { get; set; }
    }
}
