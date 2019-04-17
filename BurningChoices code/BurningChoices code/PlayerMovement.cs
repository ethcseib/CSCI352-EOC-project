using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace BurningChoices_code
{
    class PlayerMovement
    {
        BitmapImage bit;
        Image character;
        Canvas can;//mightnot be needed

        public PlayerMovement(Image character, Canvas can)
        {
            this.character = character;
            this.can = can;
            bit = new BitmapImage();
        }
        //Too much reuse i'm sure there is a better way of doing this
        public void RestrictRight(KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }

            else if (e.Key == Key.S)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }

            else if (e.Key == Key.A)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }

            else if (e.Key == Key.D)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
            }
        }

        public void RestrictDown(KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }

            else if (e.Key == Key.S)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                //Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }

            else if (e.Key == Key.A)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }

            else if (e.Key == Key.D)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
            }
        }

        public void RestrictUp(KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                //Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }

            else if (e.Key == Key.S)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }

            else if (e.Key == Key.A)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }

            else if (e.Key == Key.D)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
            }
        }

        public void RestrictLeft(KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }

            else if (e.Key == Key.S)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }

            else if (e.Key == Key.A)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                //Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }

            else if (e.Key == Key.D)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
            }
        }

        public void MoveFreely(KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
            }
            else if (e.Key == Key.S)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetTop(character, Canvas.GetTop(character) + 10);
            }
            else if (e.Key == Key.A)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
            }
            else if (e.Key == Key.D)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
                Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
            }
        }
    }
}
