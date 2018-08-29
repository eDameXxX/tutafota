using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Imaging;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Fotooo.Helpers;
using Windows.Storage;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using Newtonsoft.Json;
using Fotooo.Models;
using static Fotooo.Models.NotePage;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fotooo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Settings : Page
    {
        private string _mailAddress;
        private string _displayName = null;
        public static string token;

        public static ApplicationDataContainer _settings = ApplicationData.Current.RoamingSettings;
        private OneNoteHelper _oneNoteHelper = new OneNoteHelper();

        public Notebook notebooks = null;
        public Start pages  = null;

        public static Settings currentSettings;
        public Settings()
        {
            currentSettings = this;
            this.InitializeComponent();
        }


        /// <summary>
        /// Signs in the current user.
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SignInCurrentUserAsync()
        {
            token = await AuthenticationHelper.GetTokenForUserAsync();
            Debug.WriteLine("TOKEN: ", token);

            if (token != null)
            {
                _mailAddress = (string)_settings.Values["userEmail"];
                _displayName = (string)_settings.Values["userName"];
                return true;
            }
            else
            {
                return false;
            }

        }

        public string getToken()
        {
            return token;
        }

        private async void LoginOneNote_Click(object sender, RoutedEventArgs e)
        {
            ProgressRing.IsActive = true;
            if (await SignInCurrentUserAsync())
            {
                InfoText.Text = "Hi " + _displayName + "," + Environment.NewLine; //+ ResourceLoader.GetForCurrentView().GetString("SendMailPrompt");                   
                await _oneNoteHelper.getNameAndAvatarAsync();              
            }
            else
            {
                //InfoText.Text = ResourceLoader.GetForCurrentView().GetString("AuthenticationErrorMessage");
                logsOutput.Text = "can not login";
            }

            ProgressRing.IsActive = false;

        }


        private async void GetNotebooks_Click(object sender, RoutedEventArgs e)
        {
            ProgressRing.IsActive = true;
            logsOutput.Text = "getNotes_Click";
            // JObject results = await _oneNoteHelper.GetNotebooksAsync();
            string results = await _oneNoteHelper.GetNotebooksAsync();
            ProgressRing.IsActive = false;

            string jsonExample = @"{
                                    '@odata.context': 'https://graph.microsoft.com/beta/$metadata#users('edamexxx%40gmail.com')/onenote/notebooks',
                                    'value': [
                                        {
                                            'id': '0-F9A3B2C0C435A7B4!17918',
                                            'self': 'https://graph.microsoft.com/beta/users/edamexxx@gmail.com/onenote/notebooks/0-F9A3B2C0C435A7B4!17918',
                                            'createdDateTime': '2014-08-01T22:43:33.84Z',
                                            'displayName': 'Do obejrzenia',
                                            'createdBy': {
                                                'user': {
                                                    'id': 'F9A3B2C0C435A7B4',
                                                    'displayName': 'Damian Stępnik'
                                                }
                                            },
                                            'lastModifiedBy': {
                                                'user': {
                                                    'id': 'F9A3B2C0C435A7B4',
                                                    'displayName': 'Damian Stępnik'
                                                }
                                            },
                                            'lastModifiedDateTime': '2015-05-07T14:40:27.107Z',
                                            'isDefault': false,
                                            'userRole': 'Owner',
                                            'isShared': false,
                                            'sectionsUrl': 'https://graph.microsoft.com/beta/users/edamexxx@gmail.com/onenote/notebooks/0-F9A3B2C0C435A7B4!17918/sections',
                                            'sectionGroupsUrl': 'https://graph.microsoft.com/beta/users/edamexxx@gmail.com/onenote/notebooks/0-F9A3B2C0C435A7B4!17918/sectionGroups',
                                            'links': {
                                                'oneNoteClientUrl': {
                                                    'href': 'onenote:https://d.docs.live.net/f9a3b2c0c435a7b4/Do%20obejrzenia'
                                                },
                                                'oneNoteWebUrl': {
                                                    'href': 'https://onedrive.live.com/redir.aspx?cid=f9a3b2c0c435a7b4&page=edit&resid=F9A3B2C0C435A7B4!17918'
                                                }
                                            }
                                        }
                                    ]
                                }".Replace("'", "\"");

            Debug.WriteLine("Inside GetNotes_Click");
            //Debug.WriteLine(JsonConvert.ToString(results));

            notebooks = Notebook.FromJson(results);

            Debug.WriteLine("{0} notebooks",notebooks.Value.Length);
            foreach (var notebook in notebooks.Value)
            {
                Debug.WriteLine(notebook.DisplayName);
            }

            Debug.WriteLine(results);

            //JsonConvert.DeserializeObject<Notebook>(results);

            //JToken token = JObject.Parse(stringFullOfJson);

        }


        private async void GetPagesBtn_Click(object sender, RoutedEventArgs e)
        {
            ProgressRing.IsActive = true;
            logsOutput.Text = "getNotes_Click";
            // JObject results = await _oneNoteHelper.GetNotebooksAsync();
            string results = await _oneNoteHelper.GetPagesAsync();
            ProgressRing.IsActive = false;

            pages = NotePage.Start.FromJson(results);

            Debug.WriteLine("{0} notebooks", pages.ToString());
            //foreach (var page in )
          /// {
          //      Debug.WriteLine(page.DisplayName);
           // }

            Debug.WriteLine(results);
        }


        public void setLogsOutput(string value)
        {
            logsOutput.Text = value;
        }


        public void setAvatarPhoto(Stream photoStream)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.DecodePixelWidth = 600; //match the target Image.Width, not shown
            bitmapImage.SetSource(photoStream.AsRandomAccessStream());

            avatarImage.Source = bitmapImage;
        }

        private void LogoutOneNote_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("SignOut Btn");
            AuthenticationHelper.SignOut();
        }


    }
}
