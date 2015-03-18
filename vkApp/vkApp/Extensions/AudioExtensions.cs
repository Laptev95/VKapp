using System;
using vkApp.Model;
using vkApp.ViewModel;

namespace vkApp.Extensions
{
    public static class AudioExtensions
    {
        public static VkAudio ToAudio(this VkLib.Core.Audio.VkAudio audio)
        {
            var result = new VkAudio();
            result.Id = audio.Id.ToString();
            result.Title = audio.Title;
            result.Artist = audio.Artist;
            result.AlbumId = audio.AlbumId;
            result.Duration = audio.Duration;
            result.LyricsId = audio.LyricsId;
            result.OwnerId = audio.OwnerId;
            result.Source = audio.Url;
            result.GenreId = audio.GenreId;
            result.IsAddedByCurrentUser = audio.OwnerId == ViewModelLocator.Vkontakte.AccessToken.UserId;

            return result;
        }
    }
}
