using Dapper;
using Microsoft.EntityFrameworkCore;
using SpotiftDapper.Context;
using SpotiftDapper.Dtos;

namespace SpotiftDapper.Services
{
    public class SpotifyService : ISpotifyService
    {
        private readonly DapperContext _context;

        public SpotifyService(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> DanceSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where genre='dance'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> DrakeSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where artist_name='Drake'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> EminemSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where artist_name='Eminem'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<List<ResultSpotifyDto>> FilterSpotifyAsync(FilterSpotifyDto filter)
        {
            string query = @"
        SELECT TOP 50 artist_name, track_name, year, genre 
        FROM spotify_data 
        WHERE year = @Year
        AND (@ArtistName IS NULL OR artist_name LIKE '%' + @ArtistName + '%')
        AND (@TrackName IS NULL OR track_name LIKE '%' + @TrackName + '%')
        AND (@Genre IS NULL OR genre LIKE '%' + @Genre + '%')";
            var parameters = new DynamicParameters();
            parameters.Add("@ArtistName", filter.artist_name);
            parameters.Add("@TrackName", filter.track_name);
            parameters.Add("@Genre", filter.genre);
            parameters.Add("@year", filter.year);
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultSpotifyDto>(query, parameters);
            return values.ToList();
        }

        public async Task<List<ResultSpotifyDto>> GetFirst50Song()
        {
            string query = "SELECT TOP 50 artist_name , track_name, year,genre FROM spotify_data";
            var connection = _context.CreateConnection();
            var values = await connection.QueryAsync<ResultSpotifyDto>(query);
            return values.ToList();
        }

        public async Task<int> PopSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where genre='pop'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> PopularityHigherThan30Async()
        {
            string query = "Select count(*) from spotify_data where popularity>30";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> ProductYear2015CountAsync()
        {
            string query = "Select count(*) from spotify_data where year=2015";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> RihannaSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where artist_name='Rihanna'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }

        public async Task<int> SkilletSongCountAsync()
        {
            string query = "Select count(*) from spotify_data where artist_name='Skillet'";
            var connection = _context.CreateConnection();
            var count = await connection.QuerySingleAsync<int>(query);
            return count;
        }
    }
}
