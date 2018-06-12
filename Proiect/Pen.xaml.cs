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
    /// Interaction logic for Pen.xaml
    /// </summary>
    public partial class Pen : Window
    {
        public Pen()
        {
            InitializeComponent();
        }



        private void DrawPanel_KeyUp(object sender, KeyEventArgs e)
        {
            if((int)e.Key>=35 && (int)e.Key <= 68)
            {
                switch ((int)e.Key)
                {
                    case 35://1
                        strokeAttr.Width = 2;
                        strokeAttr.Height = 2;
                        break;
                    case 36://2
                        strokeAttr.Width = 4;
                        strokeAttr.Height = 4;
                        break;
                    case 37://3
                        strokeAttr.Width = 6;
                        strokeAttr.Height = 6;
                        break;
                    case 38://4
                        strokeAttr.Width = 8;
                        strokeAttr.Height = 8;
                        break;
                    case 45://b
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Blue");
                        break;
                    case 50://g
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Green");
                        break;
                    case 68://y
                        strokeAttr.Color = (Color)ColorConverter.ConvertFromString("Yellow");
                        break;
                }
            }
        }

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            var radiobutton = sender as RadioButton;
            string radioBPressed = radiobutton.Content.ToString();
            if(radioBPressed=="Draw")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Ink;
            }else if (radioBPressed == "Erase")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
            }
            else if (radioBPressed == "Select")
            {
                this.DrawingCanvas.EditingMode = InkCanvasEditingMode.Select;
            }


        }
    }
}
