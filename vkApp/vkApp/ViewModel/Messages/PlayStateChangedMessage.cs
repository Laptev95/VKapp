using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vkApp.ViewModel.Messages
{
    public enum PlayerPlayState
    {
        Opening,
        Playing,
        Paused,
        Stopped,
        Buffering
    }

    public class PlayStateChangedMessage
    {
        public PlayerPlayState NewState { get; set; }
    }
}
