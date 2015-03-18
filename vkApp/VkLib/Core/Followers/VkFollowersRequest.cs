using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using VkLib.Core.Users;

namespace VkLib.Core.Followers
{
    public class VkFollowersRequest
    {
        private readonly Vkontakte _vkontakte;

        internal VkFollowersRequest(Vkontakte vkontakte)
        {
            _vkontakte = vkontakte;
        }
        public async Task<VkItemsResponse<VkProfile>> GetFollowers(long userId)
        {
            if (_vkontakte.AccessToken == null || string.IsNullOrEmpty(_vkontakte.AccessToken.Token) || _vkontakte.AccessToken.HasExpired)
                throw new Exception("Access token is not valid.");

            var parameters = new Dictionary<string, string>();

            if (userId != 0)
                parameters.Add("user_id", userId.ToString());

            _vkontakte.SignMethod(parameters);

            var response = await new VkRequest(new Uri(VkConst.MethodBase + "execute.GetFollowers"), parameters).Execute();

            VkErrorProcessor.ProcessError(response);

            if (response.SelectToken("response.items") != null)
            {
                return new VkItemsResponse<VkProfile>(response["response"]["items"].Select(VkProfile.FromJson).ToList());
            }

            return VkItemsResponse<VkProfile>.Empty;
        }
    }
}
