using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Note.xaml
    /// </summary>
    public partial class Note : Window
    {
        public Note()
        {
            InitializeComponent();
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file(*.txt) | *.txt";
            dlg.InitialDirectory = @"c:\Desktop\";
            if (dlg.ShowDialog() == true)
            {
                Box.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file(*.txt) | *.txt";
            dlg.InitialDirectory = @"c:\Desktop\";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, Box.Text);
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Box.Text = "";
        }
    }
}
