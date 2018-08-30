using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Collections.ObjectModel;
using Fotooo.Models;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fotooo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ImagePage : Page
    {
        ObservableCollection<Models.Image> Images = new ObservableCollection<Models.Image>();

        public ImagePage()
        {
            this.InitializeComponent();

            for (int i=1; i<=10; i++)
            {
                Images.Add(new Models.Image
                {
                    ImageUrl = "ms-appx:///Assets/" + i + ".jpg",
                    SetNote()
                });
            }

        }
    }
}
