using GalaSoft.MvvmLight;
using System;
using vkApp.Services;
using VkLib.Core.Photo;
using VkLib.Core.Users;
using VkLib.Token;

namespace vkApp.ViewModel.Flyouts
{
    public class PhotoFlyoutViewModel : ViewModelBase
    {
        private VkPhoto _selectedPhoto;
        private VkPhoto _photo;

        public VkPhoto SelectedPhoto
        {
            get { return _selectedPhoto; }
            set
            {
                if (Set(ref _selectedPhoto, value))
                    LoadPhoto();
            }
        }
        public VkPhoto Photo
        {
            get { return _photo; }
            set { Set(ref _photo, value); }
        }

        public PhotoFlyoutViewModel()
        {
        }
        private async void LoadPhoto()
        {
            ViewModelLocator.Main.IsWorking = true;
            Photo = SelectedPhoto;
            Console.WriteLine("Height: " + Photo.Height);
            Console.WriteLine("Width: " + Photo.Width);
            //try
            //{
            //    var photo = await DataService.GetSelectedPhoto(SelectedPhoto.OwnerId, SelectedPhoto.Id);
            //    if (photo.Items != null && photo.Items.Count > 0)
            //    {
            //        Photo = photo.Items[0];
            //        Console.WriteLine("Height: " + Photo.Height);
            //        Console.WriteLine("Width: " + Photo.Width);
            //    }
            //    else
            //    {
            //        Console.WriteLine("Photo are null");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LoggingService.Log(ex);
            //}
            ViewModelLocator.Main.IsWorking = false;
        }
    }
}