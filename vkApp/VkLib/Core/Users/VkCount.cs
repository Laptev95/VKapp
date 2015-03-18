using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkLib.Core.Extensions;

namespace VkLib.Core.Users
{
    public class VkCount: VkProfile
    {
        /// <summary>
        /// Friend Count
        /// </summary>
        public long FriendCount { get; set; }

        /// <summary>
        /// Audio Count
        /// </summary>
        public long AudioCount { get; set; }

        /// <summary>
        /// Photo Count
        /// </summary>
        public long PhotoCount { get; set; }

        /// <summary>
        /// Group Count
        /// </summary>
        public long GroupCount { get; set; }

        /// <summary>
        /// Video Count
        /// </summary>
        public long VideoCount { get; set; }

        /// <summary>
        /// Followers Count
        /// </summary>
        public long FollowersCount { get; set; }

        /// <summary>
        /// Mutual Count
        /// </summary>
        public long MutualCount { get; set; }

        public static VkCount FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return ParseV5(json);
        }

        //VK Api v5.0
        private static VkCount ParseV5(JToken json)
        {
            var result = new VkCount();

            result.AudioCount = (long)json["Audio"];
            result.VideoCount = (long)json["Video"];
            result.PhotoCount = (long)json["Photos"];
            result.FriendCount = (long)json["Friends"];
            result.FollowersCount = (long)json["Followers"];

            if ((string)json["Groups"] != null)
                result.GroupCount = (long)json["Groups"];
            else result.GroupCount = 0;

            if ((string)json["Mutual"] != null)
                result.MutualCount = (long)json["Mutual"];
            else result.MutualCount = 0;

            var Profile = json.SelectToken("Profile")[0];

            result.Id = (long)Profile["id"];
            result.FirstName = (string)Profile["first_name"];
            result.LastName = (string)Profile["last_name"];

            if (Profile["bdate"] != null)
                result.BDate = (string)Profile["bdate"];

            if (Profile["home_town"] != null)
                if (!String.IsNullOrEmpty((string)Profile["home_town"]))
                    result.HomeTown = (string)Profile["home_town"];

            if (Profile["university_name"] != null)
                if (!String.IsNullOrEmpty((string)Profile["university_name"]))
                    result.UniverName = (string)Profile["university_name"];

            if (Profile["schools"] != null && Profile["schools"].HasValues)
            {
                if (!String.IsNullOrEmpty((string)Profile["schools"].Last["type_str"]) && !String.IsNullOrEmpty((string)Profile["schools"].Last["name"]))
                    result.Schools = (string)Profile["schools"].Last["type_str"] + " " + (string)Profile["schools"].Last["name"];
                else if (!String.IsNullOrEmpty((string)Profile["schools"].Last["name"]))
                    result.Schools = (string)Profile["schools"].Last["name"];
            }

            if (Profile["city"] != null)
                result.City = (string)Profile["city"]["title"];

            if (Profile["photo"] != null) //NOTE in some methods this used instead of photo_xx
                result.Photo = (string)Profile["photo"];

            if (Profile["photo_50"] != null)
                result.Photo = (string)Profile["photo_50"];

            if (Profile["photo_100"] != null)
                result.PhotoMedium = Profile["photo_100"].Value<string>();

            if (Profile["photo_200_orig"] != null)
                result.PhotoBig = Profile["photo_200_orig"].Value<string>();

            if (Profile["photo_200"] != null)
                result.PhotoBigSquare = Profile["photo_200"].Value<string>();

            if (Profile["photo_400_orig"] != null)
                result.PhotoLarge = Profile["photo_400_orig"].Value<string>();

            if (Profile["photo_max"] != null)
                result.PhotoMaxSquare = Profile["photo_max"].Value<string>();

            if (Profile["photo_max_orig"] != null)
                result.PhotoMax = Profile["photo_max_orig"].Value<string>();

            if (Profile["online"] != null)
                result.IsOnline = (int)Profile["online"] == 1;

            if (Profile["online_mobile"] != null)
                result.IsOnlineMobile = (int)Profile["online"] == 1;

            if (Profile["last_seen"] != null)
                result.LastSeen = DateTimeExtensions.UnixTimeStampToDateTime((long)Profile["last_seen"]["time"]);

            if (Profile["sex"] != null)
            {
                result.Sex = (VkSex)(int)Profile["sex"];
            }

            return result;
        }
    }
}
