using Fotooo.Views;
using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Fotooo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MasterDetailPage : Page
    {
        //private MainViewModel ViewModel => AppShell.Current.ViewModel;

        public MasterDetailPage()
        {
            this.InitializeComponent();

            //ViewModel.PropertyChanged += ViewModel_PropertyChanged;

        }


        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Set a flag so that, in narrow mode, details-only navigation doesn't occur if 
            // the CurrentArticle is changed solely as a side-effect of changing the CurrentFeed.
            if (AdaptiveStates.CurrentState == NarrowState)
                // Use "drill in" transition for navigating from master list to detail view
                Frame.Navigate(typeof(DetailPage), null, new DrillInNavigationTransitionInfo());       
        }


        private void AdaptiveStates_CurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            UpdateForVisualState(e.NewState, e.OldState);
        }


        private void UpdateForVisualState(VisualState newState, VisualState oldState = null)
        {
            var isNarrow = newState == NarrowState;

            if (isNarrow && oldState == DefaultState && MasterFrame.CurrentSourcePageType == typeof(ContentPage))  // CREATE NEW VIEW FOR THIS!!!
            {
                // Resize down to the detail item. Don't play a transition.
                Frame.Navigate(typeof(DetailPage), null, new SuppressNavigationTransitionInfo());
            }
        }


    }
}
