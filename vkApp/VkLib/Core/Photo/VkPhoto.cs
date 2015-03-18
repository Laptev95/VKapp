using System;
using Newtonsoft.Json.Linq;
using VkLib.Core.Extensions;

namespace VkLib.Core.Photo
{
    public class VkPhoto
    {
        public long Id { get; set; }

        public long OwnerId { get; set; }

        public string Photo_75 { get; set; }

        public string Photo_130 { get; set; }

        public string Photo_604 { get; set; }

        public string Photo_807 { get; set; }

        public string Photo_1280 { get; set; }

        public string Photo_2560 { get; set; }

        public string photo { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public static VkPhoto FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            var result = new VkPhoto();
            result.Id = (long)json["id"];
            result.OwnerId = (long)json["owner_id"];
            if ((string)json["sizes"].Last["type"] == "r")
            {
                result.photo = (string)json["sizes"].Last["src"];
                result.Height = (int)json["sizes"].Last["height"];
                result.Width = (int)json["sizes"].Last["width"];
            }
            //result.Photo_75 = (string)json["photo_75"];
            //result.Photo_130 = (string)json["photo_130"];
            //result.Photo_604 = (string)json["photo_604"];
            //result.Photo_807 = (string)json["photo_807"];
            //result.Photo_1280 = (string)json["photo_1280"];
            //result.Photo_2560 = (string)json["photo_2560"];
            //result.Width = (int)json["width"];
            //result.Height = (int)json["height"];
            result.Text = (string)json["text"];
            result.Created = DateTimeExtensions.UnixTimeStampToDateTime((long)json["date"]);

            return result;
        }
    }
}
