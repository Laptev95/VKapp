using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using vkApp.Controls;
using vkApp.Neptune.Messages;
using vkApp.Services;
using vkApp.View.Flyouts;
using VkLib.Core.Photo;
using VkLib.Core.Users;
using VkLib.Token;


namespace vkApp.ViewModel.Main
{
    public class PhotosViewModel : ViewModelBase
    {
        private ObservableCollection<VkPhotoAlbum> _albums;
        private ObservableCollection<VkPhoto> _photos;
        private VkPhotoAlbum _selectedAlbum;
        private CancellationTokenSource _cancellationToken;
        private int _totalAlbumsCount;
        //private int _selectedTabIndex;

        public RelayCommand GoToPhotoCommand { get; private set; }

        /// <summary>
        /// Albums list
        /// </summary>
        public ObservableCollection<VkPhotoAlbum> Albums
        {
            get { return _albums; }
            set { Set(ref _albums, value); }
        }

        /// <summary>
        /// Photos list
        /// </summary>
        public ObservableCollection<VkPhoto> Photos
        {
            get { return _photos; }
            set { Set(ref _photos, value); }
        }

        /// <summary>
        /// Selected album
        /// </summary>
        public VkPhotoAlbum SelectedAlbum
        {
            get { return _selectedAlbum; }
            set
            {
                if (Set(ref _selectedAlbum, value))
                {
                    CancelAsync();

                    if (value != null)
                    {
                        switch ((int)value.Id)
                        {
                            case -100:
                                Console.WriteLine("-100");
                                GetUserPhotos(_cancellationToken.Token);
                                break;
                            case -101:
                                Console.WriteLine("-101");
                                //LoadWallAudios(_cancellationToken.Token);
                                break;
                            case -102:
                                Console.WriteLine("-102");
                                //LoadFavoritesAudios(_cancellationToken.Token);
                                break;
                            case -103:
                                Console.WriteLine("-103");
                                //LoadFavoritesAudios(_cancellationToken.Token);
                                break;
                            default:
                                LoadPhotos(_cancellationToken.Token);
                                break;
                        }
                    }
                }
            }
        }

        //public int SelectedTabIndex
        //{
        //    get { return _selectedTabIndex; }
        //    set
        //    {
        //        if (Set(ref _selectedTabIndex, value))
        //        {
        //            CancelAsync();

        //            switch (_selectedTabIndex)
        //            {
        //                case 1:
        //                    Console.WriteLine("1");
        //                    //LoadNewsAudios(_cancellationToken.Token);
        //                    break;

        //                case 2:
        //                    Console.WriteLine("2");
        //                    //LoadWallAudios(_cancellationToken.Token);
        //                    break;

        //                case 3:
        //                    Console.WriteLine("3");
        //                    //LoadFavoritesAudios(_cancellationToken.Token);
        //                    break;
        //                case 4:
        //                    Console.WriteLine("4");
        //                    //LoadFavoritesAudios(_cancellationToken.Token);
        //                    break;
        //            }
        //        }
        //    }
        //}

        public PhotosViewModel()
        {
            //InitializeCommands();
        }
        //private void InitializeCommands()
        //{
        //    GoToPhotoCommand = new RelayCommand(() =>
        //    {
        //        var flyout = new FlyoutControl();
        //        flyout.FlyoutContent = new PhotoFlyout(Photos[index]);
        //        flyout.Show();
        //    });
        //}
        public void gotophoto(int index)
        {
            var flyout = new FlyoutControl();
            flyout.FlyoutContent = new PhotoFlyout(Photos[index]);
            flyout.Show();
        }
        public async void Activate()
        {
            if (Albums == null || Albums.Count == 0)
                await LoadAlbums();
        }
        private async Task LoadAlbums()
        {
            ViewModelLocator.Main.IsWorking = true;

            try
            {
                var response = await DataService.GetUserAlbums();

                var albums = response.Items;

                _totalAlbumsCount = response.TotalCount;

                if (albums == null)
                    albums = new List<VkPhotoAlbum>();

                albums.Insert(0, new VkPhotoAlbum() { Id = -1, Title = "Все фотографии" });
                albums.Insert(1, new VkPhotoAlbum() { Id = -100, Title = "Со мной" });
                albums.Insert(2, new VkPhotoAlbum() { Id = -101, Title = "С моей страницы" });
                albums.Insert(3, new VkPhotoAlbum() { Id = -102, Title = "На моей стене" });
                albums.Insert(4, new VkPhotoAlbum() { Id = -103, Title = "Сохраненные" });
                albums.Insert(5, new VkPhotoAlbum() { Id = int.MinValue }); //separator


                Albums = new ObservableCollection<VkPhotoAlbum>(albums);

                SelectedAlbum = albums[0];
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex);
            }

            ViewModelLocator.Main.IsWorking = false;
        }

        private async Task LoadPhotos(CancellationToken token)
        {
            if (SelectedAlbum == null)
                return;

            ViewModelLocator.Main.IsWorking = true;

            try
            {
                var response = await DataService.GetAllPhotos(Settings.Instance.AccessToken.UserId);
                if (response.Items != null && response.Items.Count > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Photos load cancelled");
                        return;
                    }

                    Photos = new ObservableCollection<VkPhoto>(response.Items);

                }
                else
                {
                    Photos = null;
                    Console.WriteLine("Photos are null");
                }
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex);
            }

            ViewModelLocator.Main.IsWorking = false;
        }

        private async Task GetUserPhotos(CancellationToken token)
        {
            if (SelectedAlbum == null)
                return;

            ViewModelLocator.Main.IsWorking = true;

            try
            {
                var response = await DataService.GetUserPhotos(Settings.Instance.AccessToken.UserId);
                if (response.Items != null && response.Items.Count > 0)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Photos load cancelled");
                        return;
                    }

                    Photos = new ObservableCollection<VkPhoto>(response.Items);

                }
                else
                {
                    Photos = null;
                    Console.WriteLine("Photos are null");
                }
            }
            catch (Exception ex)
            {
                LoggingService.Log(ex);
            }

            ViewModelLocator.Main.IsWorking = false;
        }

        private void CancelAsync()
        {
            if (_cancellationToken != null)
                _cancellationToken.Cancel();

            _cancellationToken = new CancellationTokenSource();
        }
    }
}