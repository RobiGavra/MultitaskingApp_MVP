using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
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
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : Window
    {
        #region Constructor
        public TicTacToe()
        {
            InitializeComponent();
            NewGame();
        }
        #endregion

        private MarkType[] results; // pastreaza valorile celulelor
        private bool player1turn; // true daca e randul lui X
        private bool gameEnded;

        private void NewGame()
        {
            results = new MarkType[9];
            for (var i = 0; i < results.Length; i++)
                results[i] = MarkType.Free;

            player1turn = true; // x o sa inceapa

            Container.Children.Cast<Button>().ToList().ForEach(button => {
                button.Content = string.Empty;
                button.Background = Brushes.Gray;

            });
            gameEnded = false;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {  //joc nou cand se termina si apasam click
                NewGame();
                return;
            }
            var button = (Button)sender;
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);
            var index = column + (row * 3);

            if (results[index] != MarkType.Free) return; // nu fac nimic daca in celula am o valoare

            if (player1turn)
            {
                results[index] = MarkType.Cross;
                button.Content = "X";
                player1turn = false;
                button.Foreground = Brushes.Cyan;
            }
            else
            {
                results[index] = MarkType.Zero;
                button.Content = "0";
                player1turn = true;
                button.Foreground = Brushes.Red;
            }

            CheckForWinner();
        }

        private void CheckForWinner()
        {
            //horizontal wins
            if (results[0] != MarkType.Free && (results[0] & results[1] & results[2]) == results[0])
            {
                gameEnded = true;
                Btn00.Background = Btn01.Background = Btn02.Background = Brushes.Purple;
                winner();
            }
            if (results[3] != MarkType.Free && (results[3] & results[4] & results[5]) == results[3])
            {
                gameEnded = true;
                Btn10.Background = Btn11.Background = Btn12.Background = Brushes.Purple;
                winner();
            }
            if (results[6] != MarkType.Free && (results[6] & results[7] & results[8]) == results[6])
            {
                gameEnded = true;
                Btn20.Background = Btn21.Background = Btn22.Background = Brushes.Purple;
                winner();
            }

            //vertical wins
            if (results[0] != MarkType.Free && (results[0] & results[3] & results[6]) == results[0])
            {
                gameEnded = true;
                Btn00.Background = Btn10.Background = Btn20.Background = Brushes.Purple;
                winner();
            }
            if (results[1] != MarkType.Free && (results[1] & results[4] & results[7]) == results[1])
            {
                gameEnded = true;
                Btn01.Background = Btn11.Background = Btn21.Background = Brushes.Purple;
                winner();
            }
            if (results[2] != MarkType.Free && (results[2] & results[5] & results[8]) == results[2])
            {
                gameEnded = true;
                Btn02.Background = Btn12.Background = Btn22.Background = Brushes.Purple;
                winner();
            }

            //diagonal wins
            if (results[0] != MarkType.Free && (results[0] & results[4] & results[8]) == results[0])
            {
                gameEnded = true;
                Btn00.Background = Btn11.Background = Btn22.Background = Brushes.Purple;
                winner();
            }
            if (results[2] != MarkType.Free && (results[2] & results[4] & results[6]) == results[2])
            {
                gameEnded = true;
                Btn02.Background = Btn11.Background = Btn20.Background = Brushes.Purple;
                winner();
            }

            if (!results.Any(r => r == MarkType.Free)) // daca nu exista nici un castigator
            {
                gameEnded = true;
                Container.Children.Cast<Button>().ToList().ForEach(button => {
                    button.Background = Brushes.Black;
                });
            }
        }
        public void winner()
        {
            MessageBox.Show("Winner !".ToString());
            
        }
    }
}
