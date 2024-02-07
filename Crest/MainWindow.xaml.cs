using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Crest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
        public partial class MainWindow : Window
        {

            private Button[] buttons;
            int player = 0;
            public MainWindow()
            {
                InitializeComponent();
                buttons = new Button[9] { bat1, bat2, bat3, bat4, bat5, bat6, bat7, bat8, bat9 };

            }
            public void Bot(string player)
            {
                Random random = new Random();
                int hod = random.Next(1, 9);

                while (buttons[hod].IsEnabled == false)
                    hod = random.Next(1, 9);


                Debug.WriteLine(hod);
                buttons[hod].Content = player;
                buttons[hod].IsEnabled = false;
            }

            private void Button_Click(object sender, RoutedEventArgs e)
            {
                switch (player)
                {
                    case 1:
                        sender.GetType().GetProperty("Content").SetValue(sender, "X");
                        sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                        Bot("O");
                        TBox.Text = "Ход крестиков";
                        break;
                    case 0:
                        sender.GetType().GetProperty("Content").SetValue(sender, "O");
                        sender.GetType().GetProperty("IsEnabled").SetValue(sender, false);
                        Bot("X");
                        TBox.Text = "Ход ноликов";

                        break;

                }
                WinDrawLose(sender, e);
            }

            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
                bclick();
            }

            public void block()
            {
                foreach (var but in buttons)
                {
                    but.IsEnabled = false;
                }
            }
        public void bclick()
        {
            foreach (var button in buttons)
            {
                button.IsEnabled = true;
                button.Content = "  ";
            }

            while (currentPlayer == 1)
            {
                Bot('O');
                WinDrawLose();
            }
        }


        public void WinDrawLose(object sender, RoutedEventArgs e)
            {
                if (buttons.All(but => but.IsEnabled == false))
                {
                    TBox.Text = "Ничья";
                }
                else if (bat1.Content == bat2.Content && bat2.Content == bat3.Content && bat3.Content.ToString() == "O" && bat4.Content == bat5.Content && bat5.Content == bat6.Content && bat6.Content.ToString() == "O"  && bat7.Content == bat8.Content && bat8.Content == bat9.Content && bat9.Content.ToString() == "O" && bat1.Content == bat5.Content && bat5.Content == bat9.Content && bat9.Content.ToString() == "O" && bat3.Content == bat5.Content && bat5.Content == bat7.Content && bat7.Content.ToString() == "O" && bat1.Content == bat4.Content && bat4.Content == bat7.Content && bat7.Content.ToString() == "O" && bat2.Content == bat5.Content && bat8.Content == bat5.Content && bat5.Content.ToString() == "O" && bat3.Content == bat6.Content && bat6.Content == bat9.Content && bat9.Content.ToString() == "O")
            {
                    block();
                TBox.Text = "Победили нолики";
                player = 1;
            }
            else if (bat1.Content == bat2.Content && bat2.Content == bat3.Content && bat3.Content.ToString() == "X" && bat4.Content == bat5.Content && bat5.Content == bat6.Content && bat6.Content.ToString() == "X" && bat7.Content == bat8.Content && bat8.Content == bat9.Content && bat9.Content.ToString() == "X" && bat1.Content == bat5.Content && bat5.Content == bat9.Content && bat9.Content.ToString() == "X" && bat3.Content == bat5.Content && bat5.Content == bat7.Content && bat7.Content.ToString() == "X" && bat1.Content == bat4.Content && bat4.Content == bat7.Content && bat7.Content.ToString() == "X" && bat2.Content == bat5.Content && bat8.Content == bat5.Content && bat5.Content.ToString() == "X" && bat3.Content == bat6.Content && bat6.Content == bat9.Content && bat9.Content.ToString() == "X")
            {
                block();

                TBox.Text = "Победили крестики";
                player = 0;
            }


        }

        private void TBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            WinDrawLose (sender, e);
        }
    }



}