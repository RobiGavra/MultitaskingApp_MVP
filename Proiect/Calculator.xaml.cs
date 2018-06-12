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
using static System.Net.Mime.MediaTypeNames;

namespace Proiect
{
    /// <summary>
    /// Interaction logic for Calculator.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        public Calculator()
        {
            InitializeComponent();
        }
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "7";
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "8";
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "9";
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "4";
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "5";
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "6";
        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "1";
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "2";
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "3";
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "0";
        }

        private void point_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + ".";
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = "";
        }

        private void lPar_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "(";
        }

        private void rPar_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + ")";
        }

        private void sum_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "+";
        }

        private void minus_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "-";
        }

        private void mult_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "*";
        }

        private void divide_Click(object sender, RoutedEventArgs e)
        {
            screen.Text = screen.Text + "/";
        }

        private void equal_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text != "")
            {
                Type scriptType = Type.GetTypeFromCLSID(Guid.Parse("0E59F1D5-1FBE-11D0-8FF2-00A0D10038BC"));

                dynamic obj = Activator.CreateInstance(scriptType, false);
                obj.Language = "javascript";
                string str = null;
                try
                {
                    var res = obj.Eval(screen.Text);
                    str = Convert.ToString(res);
                    screen.Text = screen.Text + "=" + str;
                }
                catch (SystemException)
                {
                    screen.Text = "Syntax Error";
                }
            }
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (screen.Text != "")
                screen.Text = screen.Text.Remove(screen.Text.Length - 1);
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Text file(*.txt) | *.txt";
            dlg.InitialDirectory = @"c:\Desktop\";
            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, screen2.Text);
            }
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Text file(*.txt) | *.txt";
            dlg.InitialDirectory = @"c:\Desktop\";
            if (dlg.ShowDialog() == true)
            {
                screen2.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void clean_Click(object sender, RoutedEventArgs e)
        {
            screen2.Text = "";
        }
    }
}
