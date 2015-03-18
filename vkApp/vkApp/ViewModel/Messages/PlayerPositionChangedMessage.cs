using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkApp.ViewModel.Messages
{
    public class PlayerPositionChangedMessage
    {
        public TimeSpan NewPosition { get; set; }
    }
}
