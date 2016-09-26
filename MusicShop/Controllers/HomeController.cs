using MusicShop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MusicShop.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new Store());
        }

        [HttpPost]
        public ActionResult Index(string search, string genre, int? fromYear, int? toYear)
        {
            Store StoreData = new Store();
            List<Album> albumList = (from a in StoreData.Albums
                                     select a).ToList();
            if (search != string.Empty)
            {
                albumList = albumList.Where(a => a.Title.ToLower().Contains(search.ToLower())).ToList();
            }
            if (genre != string.Empty)
            {
                albumList = albumList.Where(a => a.Genre.ToLower().Contains(genre.ToLower())).ToList();
            }
            if (fromYear != null)
            {
                albumList = albumList.Where(a => a.Year >= fromYear).ToList();
            }
            if (toYear != null)
            {
                albumList = albumList.Where(a => a.Year <= toYear).ToList();
            }
            //StoreData.Albums.Clear();
            //StoreData.Albums.AddRange(albumList);
            return PartialView("_SearchResults", albumList);
        }

        [HttpPost]
        public ActionResult Album(int id)
        {
            Store StoreData = new Store();
            var albumList = (from a in StoreData.Albums
                             where a.Id == id
                             select a).FirstOrDefault();
            return PartialView("_Album", albumList);
        }
    }
}