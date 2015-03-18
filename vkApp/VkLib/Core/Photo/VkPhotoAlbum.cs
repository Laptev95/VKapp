using System;
using System.ComponentModel;
using System.Net;
using Newtonsoft.Json.Linq;

namespace VkLib.Core.Photo
{
    public class VkPhotoAlbum : INotifyPropertyChanged
    {
        private string _title;

        public long OwnerId { get; set; }

        public long Id { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                if (_title == value)
                    return;

                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public static VkPhotoAlbum FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentException("Json can not be null.");

            var result = new VkPhotoAlbum();

            result.Id = json["id"].Value<long>();
            result.OwnerId = Math.Abs(json["owner_id"].Value<long>());
            result.Title = WebUtility.HtmlDecode(json["title"].Value<string>());
            return result;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
