namespace ImageSearchBot.Entities
{
    public class ImageSearchResponse
    {
        public string? _Type { get; set; }
        public string? ReadLink { get; set; }
        public string? WebSearchUrl { get; set; }
        public QueryContext? QueryContext { get; set; }
        public int TotalEstimatedMatches { get; set; }
        public int NextOffset { get; set; }
        public int CurrentOffset { get; set; }
        public List<Image>? Value { get; set; }
        public List<Error>? Errors { get; set; }
    }
}
