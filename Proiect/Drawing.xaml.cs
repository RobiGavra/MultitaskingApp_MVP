using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Proiect
{
    /// <summary>
    /// Interaction logic for Drawing.xaml
    /// </summary>
    public partial class Drawing : Window
    {
        public Drawing()
        {
            InitializeComponent();
        }

        private enum MyShape
        {
            Elipse,Rectangle
        }
        private MyShape currShape;
        Point start;
        Point end;


        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            start = e.GetPosition(this);
        }

        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            switch(currShape)
            {
                case MyShape.Elipse:
                DrawElipse();
                    break;
                case MyShape.Rectangle:
                    DrawRectangle();
                    break;
                default:
                    return;
            }
        }

        private void DrawElipse()
        {
            Ellipse newEllipse = new Ellipse()
            {
                Stroke = Brushes.Black,
                Fill=Brushes.Red,
                StrokeThickness=4,
                //Height=10,
                //Width=10
            };
            if (end.X >= start.X)
            {
                newEllipse.SetValue(Canvas.LeftProperty,start.X);
                newEllipse.Width = end.X - start.X;
            }
            else
            {
                newEllipse.SetValue(Canvas.LeftProperty, end.X);
                newEllipse.Width = start.X - end.X;
            }
            if (end.Y >= start.Y)
            {
                newEllipse.SetValue(Canvas.TopProperty, start.Y-50);
                newEllipse.Height = end.Y - start.Y;
            }
            else
            {
                newEllipse.SetValue(Canvas.TopProperty, end.Y-50);
                newEllipse.Height = start.Y - end.Y;
            }
            MyCanvas.Children.Add(newEllipse);
        }

        private void DrawRectangle()
        {
            Rectangle newRectangle= new Rectangle()
            {
                Stroke = Brushes.Blue,
                Fill = Brushes.Red,
                StrokeThickness = 4,
            };
            if (end.X >= start.X)
            {
                newRectangle.SetValue(Canvas.LeftProperty, start.X);
                newRectangle.Width = end.X - start.X;
            }
            else
            {
                newRectangle.SetValue(Canvas.LeftProperty, end.X);
                newRectangle.Width = start.X - end.X;
            }
            if (end.Y >= start.Y)
            {
                newRectangle.SetValue(Canvas.TopProperty, start.Y - 50);
                newRectangle.Height = end.Y - start.Y;
            }
            else
            {
                newRectangle.SetValue(Canvas.TopProperty, end.Y - 50);
                newRectangle.Height = start.Y - end.Y;
            }
            MyCanvas.Children.Add(newRectangle);
        }

        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        private void ElipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Elipse;
        }

        private void RectangleButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Rectangle;
        }


        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            MyCanvas.Children.Clear();
        }

    }
}
