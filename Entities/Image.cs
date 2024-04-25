namespace ImageSearchBot.Entities
{
    public class Image
    {
        public string? WebSearchUrl { get; set; }
        public string? Name { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? DatePublished { get; set; }
        public bool IsFamilyFriendly { get; set; }
        public string? ContentUrl { get; set; }
        public string? HostPageUrl { get; set; }
        public string? ContentSize { get; set; }
        public string? EncodingFormat { get; set; }
        public string? HostPageDisplayUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Thumbnail? Thumbnail { get; set; }
        public string? ImageInsightsToken { get; set; }
        public InsightsMetadata? InsightsMetadata { get; set; }
        public string? ImageId { get; set; }
        public string? AccentColor { get; set; }
    }
}
