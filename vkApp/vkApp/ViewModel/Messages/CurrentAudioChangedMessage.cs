using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vkApp.Model;

namespace vkApp.ViewModel.Messages
{
    public class CurrentAudioChangedMessage
    {
        public Audio OldAudio { get; set; }

        public Audio NewAudio { get; set; }
    }
}
