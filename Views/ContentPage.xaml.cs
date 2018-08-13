using Fotooo.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fotooo.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentPage : Page
    {

        ObservableCollection<Note> Notes = new ObservableCollection<Note>();

        ObservableCollection<Notebook> Notebooks = new ObservableCollection<Notebook>();

        public ContentPage()
        {
            this.InitializeComponent();
           
            /*
            string[] Titles = new string[] { "Hello World", "Important note", "To buy" };
            string[] Contents = new string[] { "Lorem Ipsum Sit Amen Lorem Ipsum Sit Amen", "This note is very imporant, you can't ignore it", "milk, bred, tomatoes" };

            for (int i = 0; i < 3; i++)
            {
                Notes.Add(new Note { Title = Titles[i], Content = Contents[i] });
            }
            */

            if (Settings.currentSettings != null)
            {
                for (int i = 0; i < Settings.currentSettings.notebooks.Value.Length; i++)
                {
                    //Debug.WriteLine(Settings.currentSettings.notebooks.Value[i].DisplayName);
                    Notes.Add(new Note
                    {
                        Title = Settings.currentSettings.notebooks.Value[i].DisplayName,
                        Content = Settings.currentSettings.notebooks.Value[i].CreatedBy.User.DisplayName
                    });
                }
            }

            else
            {

            }

            NotesListView.ItemsSource = Notes;




        }


        


    }
}
