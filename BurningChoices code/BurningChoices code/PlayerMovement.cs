/*Description: Controls player movement. Mainly to make player movement easier.*/
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
    class KeyPresses
    {
        BitmapImage bit;
        Image character;
        Canvas can;

        public KeyPresses()
        {
            bit = new BitmapImage();
        }

        public void ConnectCharacter_and_Canvas(Image character,Canvas can)
        {
            this.character = character;
            this.can = can;
        }

        public void RestrictRight(KeyEventArgs e)
        {
            bit = new BitmapImage();

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
            bit = new BitmapImage();

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
            bit = new BitmapImage();

            if (e.Key == Key.W)
            {
                bit.BeginInit();
                bit.UriSource = new Uri(@"..\..\Object Model\Movement.png", UriKind.Relative);
                bit.EndInit();

                character.Source = bit;
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
            bit = new BitmapImage();

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
            bit = new BitmapImage();

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
