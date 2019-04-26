/*Description: This is the main menu for the game. It is the first window that is opened when the game starts.*/
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

namespace BurningChoices_code
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        /*<Summary> The user picks a menu option and the main menu records the choice in a variable to be used for decision making in main. />*/

        int choice;
        public int Choice { get { return choice; } }

        public MainMenu()
        {
            choice = -1;
            InitializeComponent();
        }

        private void MainMenuImage_initialized(object sender, EventArgs e)
        {
            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/MainMenu.png", UriKind.Relative);
            bit.EndInit();

            MainMenuImage.Source = bit;

        }

        private void NewGame_CllicKed(object sender, RoutedEventArgs e)
        {
            this.Close();

            choice = 0;
        }

        private void ResumeGame_Clicked(object sender, RoutedEventArgs e)
        {
            choice = 1;
            this.Close();
        }

        private void QuitGame_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
