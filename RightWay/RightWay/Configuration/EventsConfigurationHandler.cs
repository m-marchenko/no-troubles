using RightWay.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

namespace RightWay.Configuration
{
    public class EventsConfigurationHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            XmlSerializer xs = new XmlSerializer(typeof(Events));
            using (var xr = new XmlNodeReader(section))
            {
                var res = (Events)xs.Deserialize(xr);

                #region For Debug
                /*
                res.TourEvents.Add(new TourEvent()
                {
                    Id = "stambul",
                    Title = "Стамбул - 2015",
                    EventType = EventType.Civil,
                    Start = new DateTime(2015, 4, 28),
                    Finish = new DateTime(2015, 5, 7),
                    PhotoAlbums = new List<PhotoAlbum> 
                    { 
                        { new PhotoAlbum() 
                            { 
                                Title = "Album 1",
                                Cover = new Photo() { Title = "Cover 1", Url = "~/some/cover/1" },
                                Photos = new List<Photo> {
                                    { new Photo() { Title = "Photo1 1", Url = "~/some/address/1"}},
                                    { new Photo() { Title = "Photo1 2", Url = "~/some/address/2"}},
                                },
                                PhotoSourceFile = "~/Content/source/file"
                            } 
                        }, 
                        { new PhotoAlbum() { Title = "Album 2" } }
                    },
                    VideoAlbum = new VideoAlbum()

                });

                var sb = new System.Text.StringBuilder();
                var sw = new System.IO.StringWriter(sb);
                xs.Serialize(sw, res);
*/
                #endregion

                var ps = new XmlSerializer(typeof(Photos));

                foreach ( var album in res.TourEvents.SelectMany(t => t.PhotoAlbums))
                {
                    if (!String.IsNullOrEmpty(album.PhotoSourceFile))
                    {
                        var path = album.PhotoSourceFile;

                        if (HttpContext.Current != null)
                            path = HttpContext.Current.Server.MapPath(album.PhotoSourceFile);

                        var doc = new XmlDocument();
                        doc.Load(path);
                        var node = doc.DocumentElement;
                        using (var nr = new XmlNodeReader(node))
                        {
                            var photos = (Photos)ps.Deserialize(nr);

                            if (photos != null)
                            {
                                if (album.Photos == null)
                                    album.Photos = new List<Photo>();
                                album.Photos.AddRange(photos.PhotoImages);
                            }
                        }
                    }
                }

                return res.TourEvents;
            }
        }
    }
    
    public class Events
    {
        public List<TourEvent> TourEvents { get; set; }
    }

    public class Photos
    {
        public List<Photo> PhotoImages { get; set; }
    }

}