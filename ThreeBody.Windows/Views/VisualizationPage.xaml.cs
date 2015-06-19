using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThreeBody.Windows.ViewModels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ThreeBody.Windows
{
    public sealed partial class VisualizationPage : Page
    {
        public VisualizationPage()
        {
            this.InitializeComponent();
            this.DataContext = new VisualizationViewModel();
        }

        private void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.DataContext = new VisualizationViewModel();
        }
    }
}
