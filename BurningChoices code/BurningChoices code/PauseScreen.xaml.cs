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
    /// Interaction logic for PauseScreen.xaml
    /// </summary>
    public partial class PauseScreen : Window
    {
        Window win;
        public PauseScreen(Window win)
        {
            this.win = win;
            InitializeComponent();
        }

        private void ResumeButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Convert.ToString(win));
            System.IO.File.WriteAllText("../../Saved Game/SaveGame1.txt", Convert.ToString(win));
        }

        private void QuitButton_Clicked(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
