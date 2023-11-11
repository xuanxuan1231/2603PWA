using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.Web.WebView2.Core;
using Microsoft.UI;           // Needed for WindowId.
using Microsoft.UI.Windowing; // Needed for AppWindow.
using WinRT.Interop;          // Needed for XAML/HWND interop.

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.



namespace _2603PWA
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            MyWebView.NavigationStarting += EnsureHttps;
            // no UIElement is set for titlebar, fallback titlebar is created
            Window window = App.MainWindow;
            window.ExtendsContentIntoTitleBar = true;
            //window.SetTitleBar(null);  // this line is optional as by it is null by default
        }


        //private void myButton_Click(object sender, RoutedEventArgs e)
        //{
            //myButton.Content = "Clicked";
        //}
        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Uri targetUri = new Uri(addressBar.Text);
                MyWebView.Source = targetUri;
            }
            catch (FormatException ex)
            {
                // Incorrect address entered.
            }
        }
        private void EnsureHttps(WebView2 sender, CoreWebView2NavigationStartingEventArgs args)
        {
            String uri = args.Uri;
            if (!uri.StartsWith("https://"))
            {
                MyWebView.ExecuteScriptAsync($"alert('{uri}不安全，尝试一个https链接')");
                args.Cancel = true;
            }
            else
            {
                addressBar.Text = uri;
            }
        }

        private void hugo_Click(object sender, RoutedEventArgs e)
        {
            addressBar.Text = "https://xuanxuan1231.tk";
        }

        private void more_Click(object sender, RoutedEventArgs e)
        {
            addressBar.Text = "https://more.xuanxuan1231.tk";
        }

        private void typecho_Click(object sender, RoutedEventArgs e)
        {
            addressBar.Text = "https://class.xuanxuan1231.tk";
        }
        private AppWindow GetAppWindowForCurrentWindow()
        {
            IntPtr hWnd = WindowNative.GetWindowHandle(this);
            WindowId wndId = Win32Interop.GetWindowIdFromWindow(hWnd);
            return AppWindow.GetFromWindowId(wndId);
        }

    }
}
