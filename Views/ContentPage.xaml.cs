using Fotooo.Helpers;
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

        private OneNoteHelper _oneNoteHelper = new OneNoteHelper();

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
                for (int i = 0; i < Settings.currentSettings.pages.Value.Length; i++)
                {
                    //Debug.WriteLine(Settings.currentSettings.notebooks.Value[i].DisplayName);
                    Notes.Add(new Note
                    {
                        Id = Settings.currentSettings.pages.Value[i].Id,
                        Title = Settings.currentSettings.pages.Value[i].Title
                        //Title = Settings.currentSettings.notebooks.Value[i].DisplayName,
                        //Content = Settings.currentSettings.notebooks.Value[i].CreatedBy.User.DisplayName,
                        //ContentUrl = Settings.currentSettings.pages.Value[i].Title
                    });
                }
            }

            else
            {

            }

            NotesListView.ItemsSource = Notes;


        }

        private async void Note_Click(object sender, ItemClickEventArgs e)
        {
            Debug.WriteLine("Note item: ", e.OriginalSource.ToString());
            Debug.WriteLine("Note item: ", sender.ToString());
            var note = (Note)e.ClickedItem;
            Debug.WriteLine("Note item: ", note.Title.ToString());
            string noteId = note.Id;
            string results = await _oneNoteHelper.GetNotesContentAsync(noteId);
            Debug.WriteLine("CONTENT URL: ", results);
        }

        private void NoteSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Debug.WriteLine("Note item2: ", e.AddedItems.ToString());
            //Debug.WriteLine("Note item2: ", sender.ToString());
            //var note = (Note)e.AddedItems;
            //Debug.WriteLine("Note item2: ", note.Title);
            //Debug.WriteLine("Note item2: ");
        }

        private void IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Debug.WriteLine("Note item3: ", e.ToString());
            Debug.WriteLine("Note item3: ", sender.ToString());
        }
    }
}
