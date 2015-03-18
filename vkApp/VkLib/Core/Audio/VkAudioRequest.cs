using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkLib.Core.Audio
{
    /// <summary>
    /// Audios sort type
    /// </summary>
    public enum VkAudioSortType
    {
        /// <summary>
        /// Sort by date added
        /// </summary>
        DateAdded,
        /// <summary>
        /// Sort by duration
        /// </summary>
        Duration,
        /// <summary>
        /// Sort by popularity
        /// </summary>
        Popularity
    }
    public class VkAudioRequest
    {
        private const int MAX_AUDIO_COUNT = 300;
        private readonly Vkontakte _vkontakte;
        internal VkAudioRequest(Vkontakte vkontakte)
        {
            _vkontakte = vkontakte;
        }

        public async Task<VkItemsResponse<VkAudio>> Get()
        {
            return await Get(_vkontakte.AccessToken.UserId);
        }
        public async Task<VkItemsResponse<VkAudio>> Get(long ownerId, long albumId = 0, int count = 0, int offset = 0)
        {
            var parameters = new Dictionary<string, string>();

            if (ownerId != 0)
                parameters.Add("owner_id", ownerId.ToString(CultureInfo.InvariantCulture));

            if (albumId != 0)
                parameters.Add("album_id", albumId.ToString(CultureInfo.InvariantCulture));

            if (count > 0)
                parameters.Add("count", count.ToString(CultureInfo.InvariantCulture));

            if (offset > 0)
                parameters.Add("offset", offset.ToString(CultureInfo.InvariantCulture));

            _vkontakte.SignMethod(parameters);

            var response = await new VkRequest(new Uri(VkConst.MethodBase + "audio.get"), parameters).Execute();

            if (VkErrorProcessor.ProcessError(response))
                return null;

            if (response.SelectToken("response.items") != null)
            {
                return new VkItemsResponse<VkAudio>(response["response"]["items"].Select(VkAudio.FromJson).ToList(), (int)response["response"]["count"]);
            }

            return VkItemsResponse<VkAudio>.Empty;
        }
        public async Task<VkItemsResponse<VkAudio>> Search(string query, int count = 0, int offset = 0, VkAudioSortType sort = VkAudioSortType.DateAdded, bool withLyricsOnly = false, bool autoFix = true,
            bool artistOnly = false, bool ownOnly = false)
        {
            if (_vkontakte.AccessToken == null || string.IsNullOrEmpty(_vkontakte.AccessToken.Token) || _vkontakte.AccessToken.HasExpired)
                throw new Exception("Access token is not valid.");

            if (count > MAX_AUDIO_COUNT)
                throw new ArgumentException("Maximum count is " + MAX_AUDIO_COUNT + ".");

            if (query == null)
                throw new ArgumentException("Query must not be null.");

            var parameters = new Dictionary<string, string>();

            parameters.Add("q", query);

            if (autoFix)
                parameters.Add("auto_complete", "1");

            parameters.Add("sort", ((int)sort).ToString(CultureInfo.InvariantCulture));

            if (withLyricsOnly)
                parameters.Add("lyrics", "1");

            if (artistOnly)
                parameters.Add("performer_only", "1");

            if (ownOnly)
                parameters.Add("search_own", "1");

            if (count > 0)
                parameters.Add("count", count.ToString(CultureInfo.InvariantCulture));
            else
                parameters.Add("count", MAX_AUDIO_COUNT.ToString(CultureInfo.InvariantCulture));

            if (offset > 0)
                parameters.Add("offset", offset.ToString(CultureInfo.InvariantCulture));

            _vkontakte.SignMethod(parameters);

            var response = await new VkRequest(new Uri(VkConst.MethodBase + "audio.search"), parameters).Execute();

            if (VkErrorProcessor.ProcessError(response))
                return null;

            if (response.SelectToken("response.items") != null)
            {
                return new VkItemsResponse<VkAudio>((from a in response["response"]["items"] where a.HasValues && !string.IsNullOrEmpty(a["url"].Value<string>(a)) select VkAudio.FromJson(a)).ToList(), (int)response["response"]["count"]);
            }

            return VkItemsResponse<VkAudio>.Empty;
        }
        public async Task<List<long>> SetBroadcast(long audioId = 0, long ownerId = 0, IList<long> targetIds = null)
        {
            if (_vkontakte.AccessToken == null || string.IsNullOrEmpty(_vkontakte.AccessToken.Token) || _vkontakte.AccessToken.HasExpired)
                throw new Exception("Access token is not valid.");

            var parameters = new Dictionary<string, string>();

            if (audioId != 0 && ownerId != 0)
                parameters.Add("audio", string.Format("{0}_{1}", ownerId, audioId));

            if (targetIds != null)
                parameters.Add("target_ids", string.Join(",", targetIds));

            _vkontakte.SignMethod(parameters);

            var response = await new VkRequest(new Uri(VkConst.MethodBase + "audio.setBroadcast"), parameters).Execute();

            if (VkErrorProcessor.ProcessError(response))
                return null;

            if (response["response"].HasValues)
            {
                return response["response"].Values<long>().ToList<long>();
            }

            return null;
        }
    }
}
