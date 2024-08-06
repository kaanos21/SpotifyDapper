using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SpotiftDapper.Dtos;
using SpotiftDapper.Services;
using X.PagedList.Extensions;

namespace SpotiftDapper.Controllers
{
    public class SpotifyController : Controller
    {
        private readonly ISpotifyService _spotifyservice;

        public SpotifyController(ISpotifyService spotifyservice)
        {
            _spotifyservice = spotifyservice;
        }

        public async Task<IActionResult> Index(int page=1)
        {
            var values = await _spotifyservice.GetFirst50Song();
            int pageSize = 10; // Sayfa başına öğe sayısı
            var pagedItems = values.ToPagedList(page, pageSize);
            return View(pagedItems);
        }
        [HttpGet]
        public IActionResult SearchSong() 
        { 

            return View(); 
        }


        [HttpPost]
        public async Task<IActionResult> SearchSong(FilterSpotifyDto filter)
        {
            var values = await _spotifyservice.FilterSpotifyAsync(filter);
            var processedValues = await SongResults(values); // Veriyi işlemek için çağır
            return View("SongResults", processedValues);
        }

        public async Task<List<ResultSpotifyDto>> SongResults(List<ResultSpotifyDto> values)
        {
            // Örnek: Veriyi işleyebilir veya filtreleyebilirsiniz
            // Şu an sadece aldığınız veriyi döndürüyor
            // Burada işleme veya filtreleme yapabilirsiniz
            return values;
        }
        public async Task<IActionResult> Statistics()
        {
            ViewBag.PopularityHigherThan30= await _spotifyservice.PopularityHigherThan30Async();
            ViewBag.RihannaSongCount= await _spotifyservice.RihannaSongCountAsync();
            ViewBag.EminemSongCount= await _spotifyservice.EminemSongCountAsync();
            ViewBag.SkilletSongCount= await _spotifyservice.SkilletSongCountAsync();
            ViewBag.DrakeSongCount= await _spotifyservice.DrakeSongCountAsync();
            ViewBag.ProductYear2015Count= await _spotifyservice.ProductYear2015CountAsync();
            ViewBag.PopSongCount= await _spotifyservice.PopSongCountAsync();
            ViewBag.DanceSongCount= await _spotifyservice.DanceSongCountAsync();
            return View();
        }
        public async Task<IActionResult> Tables()
        {
            ViewBag.Eminempopularity = await _spotifyservice.EminemAvgPopularity();
            ViewBag.Skilletpopularity = await _spotifyservice.SkilletAvgPopularity();
            return View();
        }

    }
}
