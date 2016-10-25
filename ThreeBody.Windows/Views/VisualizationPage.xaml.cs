using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ThreeBody.Windows.Models;
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
            RegenerateWorld();
        }

        private void ResetButton_Tapped(object sender, TappedRoutedEventArgs e)
        {
            RegenerateWorld();
        }

        private void RegenerateWorld()
        {
            var width = (double)this.ActualWidth;
            var height = (double)this.ActualHeight;
            var margin = Constants.WorldGenerationMargin;

            var minX = (int)Math.Round(margin * ActualWidth);
            var maxX = (int)Math.Round((1 - margin) * ActualWidth);
            var minY = (int)Math.Round(margin * ActualHeight);
            var maxY = (int)Math.Round((1 - margin) * ActualHeight);

            this.DataContext = new VisualizationViewModel(minX, maxX, minY, maxY);
        }
    }
}
