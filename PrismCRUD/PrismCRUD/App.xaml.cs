using Prism.Unity.Windows;
using PrismCRUD.Repositories;
using PrismCRUD.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace PrismCRUD
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App:PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();            
        }
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.Main.ToString(), null);
            return Task.FromResult<object>(true);
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
            RegisterTypeIfMissing(typeof(IPersonRepository), typeof(PersonRepositoryImpl), true);
            RegisterTypeIfMissing(typeof(IAutoCreatePersonService), typeof(AutoCreatePersonServiceImpl), true);
        }

    }
}
