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

        protected bool BoundingCheck(FrameworkElement element)
        {/*<Dissatisfaction> I do not like this. Would prefer to be able to use some of the libraries online to do this checing instead. As soon as I can figure it out />*/
            //MessageBox.Show("Checked");
            Point BottomLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character) + character.Height);
            Point TopLeft = new Point(Canvas.GetLeft(character), Canvas.GetTop(character));
            Point TopRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character));
            Point BottomRight = new Point(Canvas.GetLeft(character) + character.Width, Canvas.GetTop(character) + character.Height);

            List<Point> ElementPoints = new List<Point>();
            Point pt;
            //logic is wrong. Could be that the character is getting in the negatives
            for (int x = Convert.ToInt32(Canvas.GetLeft(element)); x <= Convert.ToInt32(Canvas.GetLeft(element) + element.Width); x++)
            {
                for(int y = Convert.ToInt32(Canvas.GetTop(element)); y <= Convert.ToInt32(Canvas.GetTop(element) + element.Height); y++)
                {/*<Summary> Stores all the points inside the element being tested for comparison />*/

                    pt = new Point(x, y);
                    ElementPoints.Add(pt);
                }
            }

            if (ElementPoints.Contains(BottomLeft))
            {
                ElementPoints.Clear();
                return true;
            }
            else if (ElementPoints.Contains(BottomRight))
            {
                ElementPoints.Clear();
                return true;
            }
            else if (ElementPoints.Contains(TopRight))
            {
                ElementPoints.Clear();
                return true;
            }
            else if (ElementPoints.Contains(TopLeft))
            {
                ElementPoints.Clear();
                return true;
            }
            else
            {
                ElementPoints.Clear();
                return false;
            }
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

            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);

            
        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {
            /*<Problem> This only applies to the object exit need to expand it to other objects rather than just the one />*/
                    /*<Solution> What if I use a list to hold the obstacles or if i can figure out how events work i could raise a flag when the player hits an obstacle />*/
            /*<Note> need to make the wall wrap around the screen to keep player from going outside the level but doing so may prove weird when overlapping walls/>*/
            Obstacle CharObj = new Obstacle();

            if (BoundingCheck(exit))
            {/*<Note> Would make a barrier class and check for that rather than the Image class />*/
                if (Canvas.GetRight(character) == Canvas.GetLeft(exit))//going right
                {
                    if (e.Key == Key.W)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.S)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.A)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
                    }

                    else if (e.Key == Key.D)
                    {
                        //Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                    }
                }

                else if(Canvas.GetBottom(character) == Canvas.GetTop(exit))//going down
                {
                    if (e.Key == Key.W)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.S)
                    {
                        //Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.A)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
                    }

                    else if (e.Key == Key.D)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                    }
                }

                else if (Canvas.GetTop(character) == Canvas.GetBottom(exit))//going up
                {/*<Problem> this part is not considered as part of the element and thus the character runs through the bottom of the wall without throwing a hit/collision />*/
                    
                    if (e.Key == Key.W)
                    {
                        //Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.S)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.A)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
                    }

                    else if (e.Key == Key.D)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                    }
                }

                else if (Canvas.GetLeft(character) == Canvas.GetRight(exit))//going left
                {
                    if (e.Key == Key.W)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.S)
                    {
                        Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                    }

                    else if (e.Key == Key.A)
                    {
                        //Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
                    }

                    else if (e.Key == Key.D)
                    {
                        Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                    }
                }
            }

            else
            {
                if (e.Key == Key.W)
                {
                    
                    Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                    character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                }
                else if (e.Key == Key.S)
                {
                    Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                    character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\PERSONMOVE.png");
                }
                else if (e.Key == Key.A)
                {
                    Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                    character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTLEFT.png");
                }
                else if (e.Key == Key.D)
                {
                    Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                    character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                }
            }
            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);
        }


        private void TraverseCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            Obstacle CharObj = new Obstacle();
            /*Point pt = new Point(Canvas.GetLeft(exit), Canvas.GetTop(exit));

            HitTestResult res = VisualTreeHelper.HitTest(canvas, pt);

            if (Convert.ToString(res.VisualHit) != "System.Windows.Controls.Image")/*<Note> This works for all images but im not satisfied. I only want  this to work for chosen images /Note>*/
            /*<Note> Vould make a barrier class and check for that rather than the image class />*/
            //MessageBox.Show(Convert.ToString(res.VisualHit));
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
            //Obstacle obs = new Obstacle();
            //Thread new_thread = new Thread(new ThreadStart(obs.ObstacleThread));

            canvas.Focusable = true;
            canvas.Focus();

            //new_thread.Start();//works fine though need to stop it if the user quits the game. Im sure there is an exit handler
        }

        private void ExitInitialized(object sender, EventArgs e)//used to open another level
        {
            Obstacle ExitImg = new Obstacle();
            Canvas.SetRight(exit, Canvas.GetLeft(exit) + exit.Width);
            Canvas.SetBottom(exit, Canvas.GetTop(exit) + exit.Height);

            exit.Stretch = Stretch.Fill;
            exit.StretchDirection = StretchDirection.Both;
            exit.Source = ExitImg.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png");
        }

        private void canvas_loaded(object sender, RoutedEventArgs e)
        {
            Obstacle ExitImg = new Obstacle();
            Canvas.SetRight(exit, Canvas.GetLeft(exit) + exit.Width);
            Canvas.SetBottom(exit, Canvas.GetTop(exit) + exit.Height);

            exit.Stretch = Stretch.Fill;
            exit.StretchDirection = StretchDirection.Both;
            exit.Source = ExitImg.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png");
        }

        private void BoundingRectangle_Initialized(object sender, EventArgs e)
        {
            Canvas.SetLeft(rect, Canvas.GetLeft(character));
            Canvas.SetTop(rect, Canvas.GetTop(character));
        }
    }

    class Obstacle//really hasn't been used yet
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