using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Fotooo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AppShell : Page
    {
        public static AppShell Current = null;

        //public MainViewModel ViewModel { get; } = new MainViewModel();

        public AppShell()
        {
            this.InitializeComponent();
            Current = this;


            ListView listViewMenu = new ListView();
            listViewMenu.Items.Add("Option 1");
            listViewMenu.Items.Add("Option 2");
            listViewMenu.Items.Add("Option 3");
            listViewMenu.Items.Add("Option 4");

            MainFrame.Navigate(typeof(Views.HomePage));
           
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Debug.WriteLine("AppShell OnVaigatedTo: {0}", e.SourcePageType);
            base.OnNavigatedTo(e);
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Views.HomePage)); 
        }

        private void OneNoteBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Views.ContentPage), e);
            Debug.WriteLine("OneNote btn: e: {0}", e.OriginalSource);
            Debug.WriteLine("OneNote btn: sender: {0}", sender);
        }

        private void EvernoteBtn_Click(object sender, RoutedEventArgs e)
        {

        }       

        private void FavBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(MasterDetailPage));
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(typeof(Views.Settings), e);
        }
    }
}
