using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VkLib.Core.Auth
{
    public enum MediaEngine
    {
        /// <summary>
        /// Windows Media Player engine
        /// </summary>
        Wmp,
        /// <summary>
        /// NAudio engine
        /// </summary>
        NAudio
    }
    public class AccessToken
    {
        /// <summary>
        /// Access token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// Token expiration date
        /// </summary>
        public DateTime ExpiresIn { get; set; }

        /// <summary>
        /// Has token expired
        /// </summary>
        public bool HasExpired
        {
            get { return DateTime.Now > ExpiresIn; }
        }

        /// <summary>
        /// User id associated with this token
        /// </summary>
        public long UserId { get; set; }
    }
}
