using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace RightWay.Models
{
    [Serializable]
    public class TourEvent
    {
        [XmlAttribute]
        public string Id { get; set; }

        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public DateTime Start { get; set; }

        [XmlAttribute]
        public DateTime Finish { get; set; }

        [XmlArray]
        public List<PhotoAlbum> PhotoAlbums { get; set; }

        public VideoAlbum VideoAlbum { get; set; }

        public EventReport Report { get; set; }

        public List<EventParticipant> Participants { get; set; }

        [XmlAttribute]
        public EventType EventType { get; set; }
    }

    /// <summary>
    /// Фото альбом
    /// </summary>
    [Serializable]
    public class PhotoAlbum
    {

        [XmlAttribute]
        public string Id { get; set; }

        /// <summary>
        /// Название альбома
        /// </summary>
        [XmlAttribute]
        public string Title { get; set; }

        /// <summary>
        /// Обложка
        /// </summary>
        private Photo _cover;
        public Photo Cover
        {
            get
            {
                if (_cover == null)
                {
                    if (Photos != null && Photos.Any())
                        return Photos.First();
                }

                return _cover;
            }
            set { _cover = value; }
        }

        /// <summary>
        /// Фотографии
        /// </summary>
        public List<Photo> Photos { get; set; }

        /// <summary>
        /// Имя файла (Url) со списком фотографий
        /// </summary>
        [XmlAttribute]
        public string PhotoSourceFile { get; set; }
    }

    /// <summary>
    /// Фотография
    /// </summary>
    [Serializable]
    public class Photo
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Url { get; set; }

    }

    /// <summary>
    /// Отчет
    /// </summary>
    public class EventReport
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Url { get; set; }
    }

    /// <summary>
    /// Участник
    /// </summary>
    public class EventParticipant
    {
        [XmlAttribute]
        public string Title { get; set; }

        public Photo FacePicture { get; set; }
    }

    public class VideoClip
    {
        [XmlAttribute]
        public string Title { get; set; }

        [XmlAttribute]
        public string Url { get; set; }
    }

    public class VideoAlbum
    {
        [XmlAttribute]
        public string Title { get; set; }

        public List<VideoClip> VideoClips { get; set; }
    }

    public enum EventType
    {
        Rafting,
        Sailing,
        Skiing,
        Civil
    }
}