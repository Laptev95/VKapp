using GalaSoft.MvvmLight.Messaging;
using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using vkApp.Neptune.Messages;
using vkApp.ViewModel;
using VkLib.Core.Auth;
using VkLib.Token;

namespace vkApp
{
    public partial class vk_auth : Window
    {
        public vk_auth()
        {
            InitializeComponent();
        }
        private const long appId = 4660767;
        private enum VkontakteScopeList
        {
            /// <summary>
            /// Пользователь разрешил отправлять ему уведомления. 
            /// </summary>
            notify = 1,
            /// <summary>
            /// Доступ к друзьям.
            /// </summary>
            friends = 2,
            /// <summary>
            /// Доступ к фотографиям. 
            /// </summary>
            photos = 4,
            /// <summary>
            /// Доступ к аудиозаписям. 
            /// </summary>
            audio = 8,
            /// <summary>
            /// Доступ к видеозаписям. 
            /// </summary>
            video = 16,
            /// <summary>
            /// Доступ к статусу пользователя.
            /// </summary>
            status = 1024,
            /// <summary>
            /// Доступ к предложениям (устаревшие методы). 
            /// </summary>
            offers = 32,
            /// <summary>
            /// Доступ к вопросам (устаревшие методы). 
            /// </summary>
            questions = 64,
            /// <summary>
            /// Доступ к wiki-страницам. 
            /// </summary>
            pages = 128,
            /// <summary>
            /// Добавление ссылки на приложение в меню слева.
            /// </summary>
            link = 256,
            /// <summary>
            /// Доступ заметкам пользователя. 
            /// </summary>
            notes = 2048,
            /// <summary>
            /// (для Standalone-приложений) Доступ к расширенным методам работы с сообщениями. 
            /// </summary>
            messages = 4096,
            /// <summary>
            /// Доступ к обычным и расширенным методам работы со стеной. 
            /// </summary>
            wall = 8192,
            /// <summary>
            /// Доступ к документам пользователя.
            /// </summary>
            docs = 131072,
            /// <summary>
            /// Доступ к группам пользователя.
            /// </summary>
            groups = 262144,
            /// <summary>
            /// Доступ к оповещениям об ответах пользователю.
            /// </summary
            notifications = 524288,
            /// <summary>
            /// Доступ к API в любое время со стороннего сервера
            /// </summary
            offline = 65536
        }

        private int scope = (int)(VkontakteScopeList.audio | VkontakteScopeList.docs | VkontakteScopeList.friends |
        VkontakteScopeList.link | VkontakteScopeList.messages | VkontakteScopeList.notes | VkontakteScopeList.notify |
        VkontakteScopeList.offers | VkontakteScopeList.pages | VkontakteScopeList.photos | VkontakteScopeList.status | VkontakteScopeList.questions |
        VkontakteScopeList.video | VkontakteScopeList.wall | VkontakteScopeList.notifications | VkontakteScopeList.groups | VkontakteScopeList.offline);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Uri url = new Uri(String.Format("https://oauth.vk.com/authorize?client_id={0}&scope={1}&redirect_uri=https://oauth.vk.com/blank.html&display=page&response_type=token", appId, scope));
            try
            {
                browser_auth.Navigate(url);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private async void browser_auth_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            if (e.Uri.ToString().IndexOf("access_token") != -1)
            {
                var _settings = new Settings();
                _settings.AccessToken = new AccessToken();

                Regex myReg = new Regex(@"(?<name>[\w\d\x5f]+)=(?<value>[^\x26\s]+)", RegexOptions.IgnoreCase | RegexOptions.Singleline);
                foreach (Match m in myReg.Matches(e.Uri.ToString()))
                {
                    if (m.Groups["name"].Value == "access_token")
                    {
                        _settings.AccessToken.Token = m.Groups["value"].Value;
                    }
                    else if (m.Groups["name"].Value == "user_id")
                    {
                        _settings.AccessToken.UserId = long.Parse(m.Groups["value"].Value);
                    }
                    else if (m.Groups["name"].Value == "expires_in")
                    {
                        if (m.Groups["value"].Value != "0")
                            _settings.AccessToken.ExpiresIn = DateTime.Now.Add(TimeSpan.FromSeconds(double.Parse(m.Groups["value"].Value)));
                        else
                            _settings.AccessToken.ExpiresIn = DateTime.Now.Add(TimeSpan.FromDays(365));
                    }
                }
                if (String.IsNullOrEmpty(_settings.AccessToken.Token))
                {
                    MessageBox.Show("Ошибка. Ключ доступа не найден.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                _settings.Save();
               // await Login();
                this.Close();
            }
        }
        //private async Task Login()
        //{
        //    await Settings.Load();
        //    if (Settings.Instance.AccessToken != null && !Settings.Instance.AccessToken.HasExpired)
        //    {
        //        ViewModelLocator.Vkontakte.AccessToken = Settings.Instance.AccessToken;
        //        ViewModelLocator.Main.ShowSidebar = true;
        //        ViewModelLocator.Main.ShowTopbar = true;

        //        Messenger.Default.Send(new NavigateToPageMessage()
        //        {
        //            Page = "/Main.ProfileView"
        //        });
        //    }
        //}
    }
}