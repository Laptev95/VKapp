using System.Collections.Generic;

namespace vkApp.Neptune.Messages
{
    public class NavigateToPageMessage
    {
        /// <summary>
        /// Page
        /// </summary>
        public string Page { get; set; }

        /// <summary>
        /// Params
        /// </summary>
        public Dictionary<string, object> Parameters { get; set; }
    }
}
