using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Forms;

namespace Proiect
{
    /// <summary>
    /// Interaction logic for Play.xaml
    /// </summary>
    public partial class Play : Window
    {
        public Play()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MediaElement.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog f;
            f = new OpenFileDialog();
            f.AddExtension = true;
            f.DefaultExt = "*.*";
            f.Filter = "Media Files (*.*)|*.*";
            f.ShowDialog();

            try { MediaElement.Source = new Uri(f.FileName); }
            catch { new NullReferenceException("Error"); }

            System.Windows.Threading.DispatcherTimer timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0,0,1);
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            slider1.Value = MediaElement.Position.TotalMinutes;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MediaElement.Pause();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MediaElement.Stop();
        }

        private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan t = TimeSpan.FromMinutes(e.NewValue);
            MediaElement.Position = t;
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            MediaElement.Volume = slider2.Value;
        }
    }
}
