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
    /// Interaction logic for Level2Good.xaml
    /// </summary>
    public partial class Level2Good : Window
    {
        public Level2Good()
        {
            InitializeComponent();
        }

        private void CanvasLoaded(object sender, RoutedEventArgs e)
        {
            Level2Canvas.Focusable = true;
            Level2Canvas.Focus();

            BitmapImage bit = new BitmapImage();
            
            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            character.Source = bit;

            bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/Home.png", UriKind.Relative);
            bit.EndInit();
            house.Source = bit;
        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            PlayerMovement move = new PlayerMovement(character, Level2Canvas);
            move.MoveFreely(e);
        }
    }
}
