using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Navigation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static int count = 0;

        public MainPage()
        {
            this.InitializeComponent();
            contentFrame.Navigated += Navigated;                    
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested += BackNavigationManager;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            SystemNavigationManager.GetForCurrentView().BackRequested -= BackNavigationManager;
        }

        private void BackNavigationManager(object sender, BackRequestedEventArgs e)
        {
            GoBack_Click(sender, null);           
        }

        private void Navigated(object sender, NavigationEventArgs e)
        {
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = contentFrame.CanGoBack ? AppViewBackButtonVisibility.Visible : AppViewBackButtonVisibility.Collapsed;
        }

        private void Page1_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Page1),$"Test {count++}");
        }

        private void Page2_Click(object sender, RoutedEventArgs e)
        {
            contentFrame.Navigate(typeof(Page2));
        }

        private void GoBack_Click(object sender, RoutedEventArgs e)
        {
            if (contentFrame.CanGoBack)
            {
                contentFrame.GoBack();
            }

        }

        private void GoForward_Click(object sender, RoutedEventArgs e)
        {
            if (contentFrame.CanGoForward)
            {
                contentFrame.GoForward();
            }
        }
    }
}
