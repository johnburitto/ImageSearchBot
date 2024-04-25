using ImageSearchBot.Entities;

namespace ImageSearchBot.HttpInfrastructure
{
    public interface IImageSearchService
    {
        Task<ImageSearchResponse?> Search(string query, int count = 10);
    }
}
