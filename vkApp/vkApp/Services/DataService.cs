using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using vkApp.Extensions;
using vkApp.Model;
using vkApp.ViewModel;
using VkLib;
using VkLib.Core.Audio;
using VkLib.Core.Auth;
using VkLib.Core.Friends;
using VkLib.Core.Groups;
using VkLib.Core.Photo;
using VkLib.Core.Users;
using VkLib.Error;
using VkLib.Token;
using VkAudio = vkApp.Model.VkAudio;

namespace vkApp.Services
{
    public static class DataService
    {
        private static readonly Vkontakte _vkontakte;
        static DataService()
        {
            _vkontakte = ViewModelLocator.Vkontakte;
        }
        public static async Task<string> Login ()
        {
            try
            {
                var login = _vkontakte.Auth.GetAuthUrl(VkScopeSettings.IamTheGod, VkAuthDisplayType.Popup);
                return login;
            }
            catch
            {
                return null;
            }
        }
        public static async Task<ItemsResponse<VkAudio>> GetUserTracks(int count = 0, int offset = 0, long albumId = 0, long ownerId = 0)
        {
            try
            {
                var response = await _vkontakte.Audio.Get(ownerId, albumId, count, offset);
                if (response.Items != null)
                {
                    return new ItemsResponse<VkAudio>(response.Items.Select(i => i.ToAudio()).ToList(), response.TotalCount);
                }
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();
                AccountManager.LogOutVk();
            }
            return ItemsResponse<VkAudio>.Empty;
        }
        public static async Task<VkAudio> GetAudioByArtistAndTitle(string artist, string title)
        {
            var audios = await SearchAudio(artist + " - " + title, 10, 0);
            if (audios != null && audios.Count > 0)
            {
                var audio = audios.FirstOrDefault(x => (String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase) && String.Equals(x.Artist, artist, StringComparison.OrdinalIgnoreCase)));
                if (audio == null)
                    audio = audios.FirstOrDefault(x => String.Equals(x.Title, title, StringComparison.OrdinalIgnoreCase));
                if (audio == null)
                {
                    audio = audios.First();
                }

                return audio;
            }
            else
            {
                bool searchAgain = false;
                if (artist.Contains("(") && artist.Contains(")"))
                {
                    artist = artist.Substring(0, artist.IndexOf("(")) + artist.Substring(artist.LastIndexOf(")") + 1);
                    searchAgain = true;
                }

                if (title.Contains("(") && title.Contains(")"))
                {
                    title = title.Substring(0, title.IndexOf("(")) + title.Substring(title.LastIndexOf(")") + 1);
                    searchAgain = true;
                }

                if (searchAgain)
                    return await GetAudioByArtistAndTitle(artist, title);
            }

            return null;
        }
        public static async Task<List<VkAudio>> SearchAudio(string query, int count = 0, int offset = 0)
        {
            var vkAudios = await _vkontakte.Audio.Search(query, count, offset, VkAudioSortType.DateAdded, false, false);
            if (vkAudios.Items != null)
            {
                var result = (from a in vkAudios.Items
                              select a.ToAudio()).ToList();

                return result;
            }

            return null;
        }
        public static async Task<bool> SetMusicStatus(VkAudio audio, List<long> targetIds = null)
        {
            if (audio != null)
            {
                var result = await _vkontakte.Audio.SetBroadcast(long.Parse(audio.Id), audio.OwnerId, targetIds);

                return result != null;
            }
            else
            {
                var resultnull = await _vkontakte.Audio.SetBroadcast(0,0,targetIds);
                return resultnull != null;
            }
        }
        public static async Task<VkProfile> GetUserInfo(long UserID = 0, string fields = null)
        {
            try
            {
                var info = await _vkontakte.Users.Get(UserID, fields);
                return info;
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();
                AccountManager.LogOutVk();
            }

            return null;
        }
        public static async Task<ItemsResponse<VkProfile>> GetFriends(long userId = 0, int count = 0, int offset = 0, string fields = null)
        {
            var response = await _vkontakte.Friends.Get(userId, fields, null, count, offset, FriendsOrder.ByRating);
            if (response.Items != null)
            {
                return new ItemsResponse<VkProfile>(response.Items, response.TotalCount);
            }

            return ItemsResponse<VkProfile>.Empty;
        }
        public static async Task<ItemsResponse<VkGroup>> GetGroups(int count = 0, int offset = 0, long userId = 0, string fields = null)
        {
            var response = await _vkontakte.Groups.Get(userId, fields, null, count, offset);
            if (response.Items != null)
            {
                return new ItemsResponse<VkGroup>(response.Items, response.TotalCount);
            }

            return ItemsResponse<VkGroup>.Empty;
        }
        public static async Task<VkGroupById> GetGroupById(long groupId = 0, string fields = null)
        {
            try
            {
                var info = await _vkontakte.Groups.GetById(groupId, fields);
                return info;
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();
                AccountManager.LogOutVk();
            }

            return null;
        }
        public static async Task<VkCount> GetProfile(long UserID = 0, string what = null, string fields = null)
        {
            try
            {
                var info = await _vkontakte.Users.GetProfile(UserID, what, fields);
                return info;
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();
                AccountManager.LogOutVk();
            }

            return null;
        }
        public static async Task<ItemsResponse<VkProfile>> GetFollowers(long userId = 0)
        {
            var response = await _vkontakte.Followers.GetFollowers(userId);
            if (response.Items != null)
            {
                return new ItemsResponse<VkProfile>(response.Items);
            }

            return ItemsResponse<VkProfile>.Empty;
        }
        public static async Task<ItemsResponse<VkPhotoAlbum>> GetUserAlbums(int count = 0, int offset = 0, long ownerId = 0)
        {
            try
            {
                var response = await _vkontakte.Photos.GetPhotoAlbums(ownerId, count, offset);
                if (response.Items != null)
                {
                    return new ItemsResponse<VkPhotoAlbum>(response.Items, response.TotalCount);
                }
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();

                AccountManager.LogOutVk();
            }

            return ItemsResponse<VkPhotoAlbum>.Empty;
        }
        public static async Task<ItemsResponse<VkPhoto>> GetAllPhotos(long ownerId = 0, int count = 0, int offset = 0)
        {
            try
            {
                var response = await _vkontakte.Photos.GetAllPhotos(ownerId, count, offset);
                {
                    return new ItemsResponse<VkPhoto>(response.Items, response.TotalCount);
                }
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();

                AccountManager.LogOutVk();
            }


            return ItemsResponse<VkPhoto>.Empty;
        }
        public static async Task<ItemsResponse<VkPhoto>> GetUserPhotos(long ownerId = 0, int count = 0, int offset = 0)
        {
            try
            {
                var response = await _vkontakte.Photos.GetUserPhotos(ownerId, count, offset);
                {
                    return new ItemsResponse<VkPhoto>(response.Items, response.TotalCount);
                }
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();

                AccountManager.LogOutVk();
            }


            return ItemsResponse<VkPhoto>.Empty;
        }
        public static async Task<ItemsResponse<VkPhoto>> GetSelectedPhoto(long ownerId = 0, long photoId = 0)
        {
            try
            {
                var response = await _vkontakte.Photos.GetSelectedPhoto(ownerId, photoId);
                {
                    return new ItemsResponse<VkPhoto>(response.Items);
                }
            }
            catch (VkInvalidTokenException)
            {
                Settings.Instance.AccessToken = null;
                Settings.Instance.Save();

                AccountManager.LogOutVk();
            }


            return ItemsResponse<VkPhoto>.Empty;
        }
    }
}
