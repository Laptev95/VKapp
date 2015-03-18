using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VkLib.Core.Audio;
using VkLib.Core.Auth;
using VkLib.Core.Followers;
using VkLib.Core.Friends;
using VkLib.Core.Groups;
using VkLib.Core.Photo;
using VkLib.Core.Users;

namespace VkLib
{
    public class Vkontakte
    {
        private readonly string _appId;
        private string _apiVersion = "5.9";

        /// <summary>
        /// App ID
        /// </summary>
        internal string AppId
        {
            get { return _appId; }
        }

        /// <summary>
        /// Api version
        /// </summary>
        public string ApiVersion
        {
            get { return _apiVersion; }
            set { _apiVersion = value; }
        }
        /// <summary>
        /// Access token
        /// </summary>
        public AccessToken AccessToken { get; set; }

        /// <summary>
        /// OAuth
        /// </summary>
        public VkOAuthRequest OAuth
        {
            get
            {
                return new VkOAuthRequest(this);
            }
        }
        public VkOAuthRequest Auth
        {
            get
            {
                return new VkOAuthRequest(this);
            }
        }
        /// <summary>
        /// Audio
        /// </summary>
        public VkAudioRequest Audio
        {
            get
            {
                return new VkAudioRequest(this);
            }
        }
        public VkUsersRequest Users
        {
            get
            {
                return new VkUsersRequest(this);
            }
        }
        /// <summary>
        /// Photos
        /// </summary>
        public VkPhotosRequest Photos
        {
            get
            {
                return new VkPhotosRequest(this);
            }
        }
        public VkFriendsRequest Friends
        {
            get
            {
                return new VkFriendsRequest(this);
            }
        }
        public VkGroupsRequest Groups
        {
            get
            {
                return new VkGroupsRequest(this);
            }
        }
        public VkFollowersRequest Followers
        {
            get
            {
                return new VkFollowersRequest(this);
            }
        }

        public Vkontakte(string appId, string apiVersion = null)
        {
            AccessToken = new AccessToken();

            ApiVersion = apiVersion;
            _appId = appId;
        }

        internal void SignMethod(Dictionary<string, string> parameters)
        {
            if (parameters == null)
                parameters = new Dictionary<string, string>();

            parameters.Add("access_token", AccessToken.Token);

            if (!string.IsNullOrEmpty(ApiVersion))
                parameters.Add("v", ApiVersion);
        }
    }
}
