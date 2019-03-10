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
using System.Threading;

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
            bitmap.UriSource = new Uri(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSON.png", UriKind.RelativeOrAbsolute);
            bitmap.EndInit();

            character.Source = bitmap;
        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {
            /*<Note> Could use a function like this to determine hit detection</Note>*/
            Obstacle CharObj = new Obstacle();

            if (e.Key == Key.W)
            {/*<Note> Might be able to modify .Bottom and .Right to provide more area of no collide rather than just one point/>*/
                /*<Problem> Only applies to the exit element going to have find an event function for collisions between 2 elements />*/
                //MessageBox.Show(Convert.ToString(Canvas.GetBottom(exit)));

                if (Canvas.GetTop(character) < Canvas.GetTop(exit) || Canvas.GetLeft(character) < Canvas.GetLeft(exit))
                Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
            }
            if (e.Key == Key.S)
            {
                //if (Canvas.GetTop(character) > Canvas.GetTop(exit))
                    Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
            }
            else if (e.Key == Key.A)
            {
                if (Canvas.GetLeft(character) < Canvas.GetLeft(exit) || Canvas.GetTop(character) < Canvas.GetTop(exit))/*<Problem> If character gets too low on the canvas then it can no longer go right/>*/
                    Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
            }
            else if (e.Key == Key.D)
            {
                //if (Canvas.GetLeft(character) != Canvas.GetLeft(exit))
                    Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
            }
        }

        private void TraverseCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            Obstacle CharObj = new Obstacle();

            if (e.Key == Key.W)
            {
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\STANDSTILL.png");
            }
            else if (e.Key == Key.S)
            {
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\STANDSTILL.png");
            }
            else if (e.Key == Key.A)
            {
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\STANDSTILL.png");
            }
            else if (e.Key == Key.D)
            {
                character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\STANDSTILL.png");
            }
        }

        private void CanvasInitialized(object sender, EventArgs e)//allows the canvas to take input which allows things like image movement
        {
            Obstacle obs = new Obstacle();
            //Thread new_thread = new Thread(new ThreadStart(obs.ObstacleThread));

            canvas.Focusable = true;
            canvas.Focus();

            //new_thread.Start();//works fine though need to stop it if the user quits the game. Im sure there is an exit handler
        }

        private void ExitInitialized(object sender, EventArgs e)//used to open another level
        {
            Obstacle ExitImg = new Obstacle();
            exit.Source = ExitImg.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Bandersnatch_Clone_Environment(1).jpg");
        }
    }

    class Obstacle
    {
        BitmapImage ObjImg = new BitmapImage();//might make this static for later levels

        public void ObstacleThread()//to constantly check if the character is trying to pass through walls
        {
            int e = 1;
            while (true)
            {
                e++;
                //MessageBox.Show(Convert.ToString(e));

                //Thread.Sleep(3000);
            }
        }

        public BitmapImage Image(string ImgSource)
        {

            ObjImg.BeginInit();
            ObjImg.UriSource = new Uri(@ImgSource, UriKind.RelativeOrAbsolute);
            ObjImg.EndInit();

            return ObjImg;
        }
    }
}
/*plan: can use canvas.Left and canvas.Bottom to get the area of an element if i need to check if the character tries to walk over a wall. Perhaps can use threading to do this check.*/
/*<Problems> The program could run into threading problems due running threads on multiple obstacles for checking hit detection. Might have to look into another solution </Problem>*/
/*<Note> Might be able to use the decorator and wrap the walls in a hit box for hit detection</Note>*/