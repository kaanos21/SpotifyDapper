using SpotiftDapper.Dtos;

namespace SpotiftDapper.Services
{
    public interface ISpotifyService
    {
        Task<List<ResultSpotifyDto>> GetFirst50Song();
        Task<List<ResultSpotifyDto>> FilterSpotifyAsync(FilterSpotifyDto filter);
        Task<int> RihannaSongCountAsync();
        Task<int> EminemSongCountAsync();
        Task<int> SkilletSongCountAsync();
        Task<int> DrakeSongCountAsync();
        Task<int> ProductYear2015CountAsync();
        Task<int> PopSongCountAsync();
        Task<int> DanceSongCountAsync();
        Task<int> PopularityHigherThan30Async();
    }
}
