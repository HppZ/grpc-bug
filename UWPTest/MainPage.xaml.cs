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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<string> _source;
        public MainPage()
        {
            this.InitializeComponent();

            _source = new ObservableCollection<string>(Enumerable.Range(0, 20).Select(x=>x.ToString()));
            ListView1.ItemsSource = _source;

            Debug.WriteLine($"{ListView1.Items.GetHashCode()}");
            ListView1.Items.VectorChanged += Items_VectorChanged;
            Debug.WriteLine($"{ListView1.Items.GetHashCode()}");
        }

        private void Items_VectorChanged(IObservableVector<object> sender, IVectorChangedEventArgs @event)
        {
            Debug.WriteLine($"{sender.GetHashCode()}");
            Debug.WriteLine($"{ListView1.Items.GetHashCode()}");
        }

        private void UIElement_OnTapped(object sender, TappedRoutedEventArgs e)
        {
            _source.Remove((sender as FrameworkElement).DataContext as string);
        }
    }
}
