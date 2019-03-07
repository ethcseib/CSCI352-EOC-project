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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BurningChoices_code
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CharacterInitialized(object sender, EventArgs e)
        {
            /*<Summary> establishes the main character model. bitmap.UriSource will have to change depending on where the images are located on the pc. Could change it to "mlg.jpg" if the image
             is moved to the .exe folder </Summary>*/

            BitmapImage bitmap = new BitmapImage();//system.Windows.Media.BitmapImage rather than Sytem.Drawing

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"C:\Users\Ethan Seiber\Documents\1 School\1 Programming\csci352\Burnining Choices\BurningChoices\Image Assets\mlg.jpg", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            character.Source = bitmap;
        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {
            if (e.Key == Key.W)
            {
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }
            if (e.Key == Key.S)
            {
                Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }
            else if (e.Key == Key.A)
            {
                Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }
            else if (e.Key == Key.D)
            {
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
            }

        }

        private void CanvasInitialized(object sender, EventArgs e)//allows the canvas to take input which allows things like image movement
        {
            canvas.Focusable = true;
            canvas.Focus();
        }
    }
}
/*plan: take the grid creating many tiny cells and then traverse over them to simulate movement*/