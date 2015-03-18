using System;
using Newtonsoft.Json.Linq;
using VkLib.Core.Extensions;
using System.Globalization;
using System.Windows.Documents;

namespace VkLib.Core.Users
{
    public enum VkSex
    {
        Uknown = 0,
        Female = 1,
        Male = 2,
    }

    /// <summary>
    /// User profile
    /// <seealso cref="http://vk.com/dev/fields"/>
    /// </summary>
    public class VkProfile : VkProfileBase
    {
        /// <summary>
        /// First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Full name
        /// </summary>
        public override string Name
        {
            get { return FirstName + " " + LastName; }
        }

        /// <summary>
        /// Sex
        /// </summary>
        public VkSex Sex { get; set; }

        /// <summary>
        /// Is online
        /// </summary>
        public bool IsOnline { get; set; }

        /// <summary>
        /// Is online from mobile device
        /// </summary>
        public bool IsOnlineMobile { get; set; }

        /// <summary>
        /// Last seen
        /// </summary>
        public DateTime LastSeen { get; set; }

        /// <summary>
        /// Home town
        /// </summary>
        public string HomeTown { get; set; }
        public string BDate { get; set; }

        /// <summary>
        /// BirthDay
        /// </summary>
        public override string BirthDay
        {
            get
            {
                if (BDate == null)
                    return null;

                if (BDate.Length > 5)
                {
                    DateTime time = DateTime.Parse(BDate);
                    return String.Format(CultureInfo.CreateSpecificCulture("ru-RU"), "{0:d MMMM yyyy} г.", time);
                }
                else
                {
                    DateTime time = DateTime.ParseExact(BDate, "d.M", CultureInfo.InvariantCulture);
                    return String.Format(CultureInfo.CreateSpecificCulture("ru-RU"), "{0:d MMMM}", time);
                }
            }
        }

        /// <summary>
        /// Study place
        /// </summary>
        public override string StudyPlace
        {
            get
            {
                if (!String.IsNullOrEmpty(UniverName))
                    return UniverName;
                return Schools;
            }
        }

        /// <summary>
        /// university name
        /// </summary>
        public string UniverName { get; set; }

        /// <summary>
        /// Schools
        /// </summary>
        public string Schools { get; set; }

        /// <summary>
        /// City
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Was Online
        /// </summary>
        public override string WasOnline
        {
            get
            {
                if (LastSeen > DateTime.Now.AddHours(-1))
                {
                    TimeSpan time = DateTime.Now - LastSeen;
                    if (Sex.ToString() == "Male")
                        return String.Format("был в сети {0:mm} минут назад", time);
                    else if (Sex.ToString() == "Female")
                        return String.Format("была в сети {0:mm} минут назад", time);
                    else
                        return String.Format("был в сети {0:mm} минут назад", time);
                }
                else
                {
                    string WasOnline = GetDay(LastSeen);
                    if (Sex.ToString() == "Male")
                        return String.Format("был в сети {0} {1:в H:mm}", WasOnline, LastSeen);
                    else if (Sex.ToString() == "Female")
                        return String.Format("была в сети {0} {1:в H:mm}", WasOnline, LastSeen);
                    else
                        return String.Format("был в сети {0} {1:в H:mm}", WasOnline, LastSeen);
                }
            }
        }

        public string GetDay(DateTime _lastSeen)
        {
            string WasOnline = "";

            DateTime LastSeen = _lastSeen;

            if (DateTime.Today > LastSeen)
                WasOnline = "вчера";
            if (DateTime.Today < LastSeen)
                WasOnline = "сегодня";
            if (LastSeen < DateTime.Today.AddDays(-1))
                WasOnline = String.Format(CultureInfo.CreateSpecificCulture("ru-RU"), "{0:d MMMM}", LastSeen);

            return WasOnline;  //String.Format("был в сети {0} {1:в HH:mm}", WasOnline, lastSeen);
        }

        public static VkProfile FromJson(JToken json)
        {
            if (json == null)
                throw new ArgumentNullException("json");

            return ParseV5(json);
        }

        //VK Api v5.0
        private static VkProfile ParseV5(JToken json)
        {
            var result = new VkProfile();

            result.Id = (long)json["id"];
            result.FirstName = (string)json["first_name"];
            result.LastName = (string)json["last_name"];

            if (json["bdate"] != null)
                result.BDate = (string)json["bdate"];

            if (json["home_town"] != null)
                if (!String.IsNullOrEmpty((string)json["home_town"]))
                    result.HomeTown = (string)json["home_town"];

            if (json["university_name"] != null)
                if (!String.IsNullOrEmpty((string)json["university_name"]))
                    result.UniverName = (string)json["university_name"];

            if (json["schools"] != null && json["schools"].HasValues)
            {
                if (!String.IsNullOrEmpty((string)json["schools"].Last["type_str"]) && !String.IsNullOrEmpty((string)json["schools"].Last["name"]))
                    result.Schools = (string)json["schools"].Last["type_str"] + " " + (string)json["schools"].Last["name"];
                else if (!String.IsNullOrEmpty((string)json["schools"].Last["name"]))
                    result.Schools = (string)json["schools"].Last["name"];
            }

            if (json["city"] != null)
                result.City = (string)json["city"]["title"];

            if (json["photo"] != null) //NOTE in some methods this used instead of photo_xx
                result.Photo = (string)json["photo"];

            if (json["photo_50"] != null)
                result.Photo = (string)json["photo_50"];

            if (json["photo_100"] != null)
                result.PhotoMedium = json["photo_100"].Value<string>();

            if (json["photo_200_orig"] != null)
                result.PhotoBig = json["photo_200_orig"].Value<string>();

            if (json["photo_200"] != null)
                result.PhotoBigSquare = json["photo_200"].Value<string>();

            if (json["photo_400_orig"] != null)
                result.PhotoLarge = json["photo_400_orig"].Value<string>();

            if (json["photo_max"] != null)
                result.PhotoMaxSquare = json["photo_max"].Value<string>();

            if (json["photo_max_orig"] != null)
                result.PhotoMax = json["photo_max_orig"].Value<string>();

            if (json["online"] != null)
                result.IsOnline = (int)json["online"] == 1;

            if (json["online_mobile"] != null)
                result.IsOnlineMobile = (int)json["online"] == 1;

            if (json["last_seen"] != null)
                result.LastSeen = DateTimeExtensions.UnixTimeStampToDateTime((long)json["last_seen"]["time"]);

            if (json["sex"] != null)
            {
                result.Sex = (VkSex)(int)json["sex"];
            }

            return result;
        }
    }
}
