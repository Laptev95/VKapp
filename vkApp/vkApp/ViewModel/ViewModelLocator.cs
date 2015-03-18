/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:vkApp.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Windows.Controls;
using vkApp.ViewModel.Main;
using VkLib;

namespace vkApp.ViewModel
{
    public class ViewModelLocator
    {
        private static readonly Vkontakte _vkontakte = new Vkontakte("4660767", "5.27");
        private static Lazy<MainViewModel> _main = new Lazy<MainViewModel>(() => new MainViewModel());
        private static Lazy<ProfileViewModel> _profile = new Lazy<ProfileViewModel>(() => new ProfileViewModel());

        static ViewModelLocator()
        {

        }
        public static Vkontakte Vkontakte
        {
            get { return _vkontakte; }
        }
        public static MainViewModel Main
        {
            get { return _main.Value; }
        }
        public static ProfileViewModel Profile
        {
            get { return _profile.Value; }
        }
        public static void Cleanup()
        {
        }
    }
}