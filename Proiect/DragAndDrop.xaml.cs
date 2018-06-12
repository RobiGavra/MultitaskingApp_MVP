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

namespace Proiect
{
    /// <summary>
    /// Interaction logic for DragAndDrop.xaml
    /// </summary>
    public partial class DragAndDrop : Window
    {
        public DragAndDrop()
        {
            InitializeComponent();
        }

        private void rect_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = (Rectangle)sender; //referinta la dreptunghi
            DataObject data = new DataObject(r.Fill);
            DragDrop.DoDragDrop(r, data, DragDropEffects.Move);
        }

        private void Target_Drop(object sender, DragEventArgs e)
        {
            SolidColorBrush s = (SolidColorBrush)e.Data.GetData(typeof(SolidColorBrush));
            Target.Fill = s;
        }
    }
}
