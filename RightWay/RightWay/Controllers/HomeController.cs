using RightWay.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RightWay.Controllers
{
    public class HomeController : Controller
    {
        private static List<TourEvent> _events = (List<TourEvent>)ConfigurationManager.GetSection("Events");

        public ActionResult Index()
        {
            ViewBag.Title = "No Troubles!";

            return View(GetEventList());
        }

        public ActionResult LoadEvent(string id)
        {
            var model = GetEventList().FirstOrDefault(e => e.Id == id);

            return PartialView("EventContent2", model);
        }

        public ActionResult LoadAlbum(string eventId, string albumId)
        {
            var model = GetEventList().FirstOrDefault(e => e.Id == eventId);

            if (model == null)
                return new PartialViewResult();

            var album = model.PhotoAlbums.FirstOrDefault(a => a.Id == albumId);
            return PartialView("EventContent1", album);
            
            
        }

        private IEnumerable<TourEvent> GetEventList()
        {
            return _events;

            // dummy
            /*
            var list = new List<TourEvent>()
            {
                new TourEvent () 
                {
                    Id = "magadan",
                    Title = "Магадан - 2015",
                    EventType = EventType.Sailing,
                    Start = new DateTime(2015, 7, 18),
                    Finish = new DateTime(2015, 8, 6),
                    Participants = new List<EventParticipant>(),
                    PhotoAlbums = new List<PhotoAlbum> { { new PhotoAlbum() } },
                    Report = new EventReport()
                },
                new TourEvent () 
                {
                    Id = "stambul",
                    Title = "Стамбул - 2015",
                    EventType = EventType.Civil,
                    Start = new DateTime(2015, 4, 28),
                    Finish = new DateTime(2015, 5, 7),
                    PhotoAlbums = new List<PhotoAlbum> 
                    { 
                        { new PhotoAlbum() { Title = "Album 1" } }, 
                        { new PhotoAlbum() { Title = "Album 2" } }
                    },
                    VideoAlbum = new VideoAlbum()
                },

                new TourEvent () 
                {
                    Id = "greece",
                    Title = "Яхтинг в Греции",
                    EventType = EventType.Sailing,
                    Start = new DateTime(2014, 9, 14),
                    Finish = new DateTime(2014, 9, 28),
                    Report = new EventReport()
                }


            };

            return list;
              */
        }
    }
}
