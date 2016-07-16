
namespace Locator.WinPhone
{
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
    using Windows.UI.Xaml.Navigation;

    using Xamarin.Forms;

    using Locator.Modules;
    using Locator.Portable.Ioc;
    using Locator.Portable.Modules;
    using Locator.Shared.Modules;
    using Locator.WinPhone.Modules;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            InitIoC();

            NavigationCacheMode = NavigationCacheMode.Required;
            LoadApplication(new Locator.App());
        }

        private void InitIoC()
        {
            IoC.CreateContainer();
            IoC.RegisterModule(new WinPhoneModule());
            IoC.RegisterModule(new SharedModule(true));
            IoC.RegisterModule(new XamFormsModule());
            IoC.RegisterModule(new PortableModule());
            IoC.StartContainer();
        }
    }
}
