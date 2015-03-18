using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using vkApp.Services.Media;
using vkApp.ViewModel.Messages;

namespace vkApp.Behaviours
{
    public class AutoScrollToCurrentItemBehaviour : Behavior<ListBox>
    {
        protected override void OnAttached()
        {
            Messenger.Default.Register<CurrentAudioChangedMessage>(this, OnCurrentAudioChanged);

            if (AudioService.CurrentAudio != null)
                AssociatedObject.ScrollIntoView(AudioService.CurrentAudio);
        }

        protected override void OnDetaching()
        {
            Messenger.Default.Unregister<CurrentAudioChangedMessage>(this, OnCurrentAudioChanged);
        }

        private void OnCurrentAudioChanged(CurrentAudioChangedMessage message)
        {
            if (AssociatedObject != null && message.NewAudio != null)
            {
                AssociatedObject.ScrollIntoView(message.NewAudio);
            }
        }
    }
}
