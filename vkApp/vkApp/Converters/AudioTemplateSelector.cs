using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using vkApp.Model;

namespace vkApp.Converters
{
    public class AudioTemplateSelector : DataTemplateSelector
    {
        public DataTemplate AudioTemplate { get; set; }

        public DataTemplate LocalAudioTemplate { get; set; }

        public DataTemplate PostTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            //if (item is AudioPost)
              //  return PostTemplate;

            if (item is LocalAudio)
                return LocalAudioTemplate;

            if (item is Audio)
                return AudioTemplate;

            return AudioTemplate;
        }
    }
}
