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
            bitmap.UriSource = new Uri("STANDSTILL.png", UriKind.RelativeOrAbsolute);//experimenting with file locations so that they can easier access the program
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
            /*<todo> I want to be able to make the character get right next to the wall rather than ten paces back. Perhaps i could do player movement - distance to wall or >= to wall. Could do
             a move to statement that sets move = to 10 rather than += 10 but only works on one obstacle until i work to make it multiple obstacle capable. Might be able to do the obstacle
             class to have this function and if the obstacle object has a property for collide that if true will make the obstacle unable to be passed through/>*/
            /*<Note> Switch statements are a thing to look into />*/
            /*<Note> strategy pattern is a thing to look into for collision behavior. Might be a problem book talks of revealing the strategies to the client. />*/
            /*<Note> observer pattern might do well for collision tracking />*/

            /*<Strategy> have a timer inside to determine when to create a thread that runs only when the keys are pressed. The timer will make the thread wait a certain amount of time before activating player 
             * run />*/
             /*<Problem> The character doesnt get close to the wall but apparently the character is supposed to be right next to it I assume its a dimensions thing I don't quite see yet />*/

            Obstacle CharObj = new Obstacle();
            GenObstacle obs = new Wall(character, canvas);//change the constructors character is static
                                                         //collision problems still

            obs.ClosestElement();//dissatisfying and didn't work or ClosestObstacle didn't work
            obs.CollisionCheck();

            //int move = 10; so we can reduce the movement code when  a collision happens to this i dont know why i thought this made sense

           if (obs.CollisionStatus)//the problem is collision is true and never gets switched back to false
           {
                //MessageBox.Show("X " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle)) + " Y " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle)));
                if (obs.collideable)//not right this is just one instance
                {
                    if (Canvas.GetRight(character) == Canvas.GetLeft(GenObstacle.ClosestObstacle))//going right
                    { //MessageBox.Show("Character " + Convert.ToString(Canvas.GetRight(character) + " obs " + Convert.ToString(Canvas.GetLeft(GenObstacle.ClosestObstacle))));
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
                            
                            //Canvas.SetLeft(character, Canvas.GetLeft(exit));//directional problem. Will require maths
                            character.Source = CharObj.Image(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\BurningChoices code\BurningChoices code\Object Models\MOVEMENTRIGHT.png");
                        }
                    }

                    else if (Canvas.GetBottom(character) == Canvas.GetTop(GenObstacle.ClosestObstacle))//going down
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetBottom(character) + " obs " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle))));
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

                    else if (Canvas.GetTop(character) == Canvas.GetBottom(GenObstacle.ClosestObstacle))//going up
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetTop(character) + " obs " + Convert.ToString(Canvas.GetBottom(GenObstacle.ClosestObstacle))));
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

                    else if (Canvas.GetLeft(character) == Canvas.GetRight(GenObstacle.ClosestObstacle))//going left
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetLeft(character) + " obs " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle))));
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
            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);//setting right and bottom
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);
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
        {/*<Problem> The ObstacleAbstractFactory feels like a decorator somewhat />*/

            /*<Note> For those planning to use the obstacle abstract factory to create walls you have to follow this implementation. 
             * You call obs.CreateObs(path to picture, height of wall, width of wall, the wall object created in the MainWindow.xaml). If you plan to create a new wall or obstacle you must do obs = new Wall(character, canvas)
             * or obs = new Door(canvas); however, only walls have really been fleshed out so the door class needs work. The abstract obstacle factory is still in development and thus certain parts are subject to change />*/

            GenObstacle obs = new Wall(character, canvas);
            
            obs.CreateObs(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png", 50, 90, wall1);//almost like a decorator needs review
            obs = new Wall(character, canvas);

            obs.CreateObs(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png", 50, 50, wall2);

            //obs.CreateObs(@"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png", 50, 50, wall3);

            canvas.Focusable = true;
            canvas.Focus();

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