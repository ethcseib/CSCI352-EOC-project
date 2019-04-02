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
            bitmap.UriSource = new Uri(@"..\..\Object Model\GUY.png", UriKind.Relative);//experimenting with file locations so that they can easier access the program
            bitmap.EndInit();

            character.Source = bitmap;

            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);

            
        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {
           
            /*<Note> Switch statements are a thing to look into />*/
            /*<Note> strategy pattern is a thing to look into for collision behavior. Might be a problem book talks of revealing the strategies to the client. />*/
            /*<Note> observer pattern might do well for collision tracking />*/

            /*<Strategy> have a timer inside to determine when to create a thread that runs only when the keys are pressed. The timer will make the thread wait a certain amount of time before activating player 
             * run />*/
            /*<Problem> I think the problem now is when the player reaches the corner then it is equidistant from two elements />*/
            /*<Question> What if i detect a collision fixing to happen and stop it from happening by not allowing movement but then you have to predict the next move />*/

            BitmapImage bit = new BitmapImage();

            /*<Problem> GenObstacle is a problem I need to work out how to do collision checking and closest element without obs />*/
            GenObstacle obs = new Wall(character, canvas, @"C:\Users\Ethan Seiber\Desktop\Burning Choices game\Wall.png", wall4);
            
            obs.ClosestElement();//gotta remove these somehow
            GenObstacle.CollisionCheck();//might look into being able to remove GenObstacle in favor of MakeObstacle

           if (obs.CollisionStatus)
           {
                //MessageBox.Show("X " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle)) + " Y " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle)));
                if (obs.collideable)
                {
                    //MessageBox.Show("Character " + Convert.ToString(Canvas.GetLeft(character) + " obs " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle))));
                    //MessageBox.Show("Character " + Convert.ToString(Canvas.GetTop(character) + " obs " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle))));
                    //MessageBox.Show("X " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle)) + " Y " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle)));
                    if (Canvas.GetRight(character) == Canvas.GetLeft(GenObstacle.ClosestObstacle))//going right
                    { //MessageBox.Show("Character " + Convert.ToString(Canvas.GetRight(character) + " obs " + Convert.ToString(Canvas.GetLeft(GenObstacle.ClosestObstacle))));
                        if (e.Key == Key.W)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        }

                        else if (e.Key == Key.S)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        }

                        else if (e.Key == Key.A)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        }

                        else if (e.Key == Key.D)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                        }
                    }

                    else if (Canvas.GetBottom(character) == Canvas.GetTop(GenObstacle.ClosestObstacle))//going down
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetBottom(character) + " obs " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle))));
                        if (e.Key == Key.W)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        }

                        else if (e.Key == Key.S)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            //Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        }

                        else if (e.Key == Key.A)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        }

                        else if (e.Key == Key.D)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        }
                    }

                    else if (Canvas.GetTop(character) == Canvas.GetBottom(GenObstacle.ClosestObstacle))//going up
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetTop(character) + " obs " + Convert.ToString(Canvas.GetBottom(GenObstacle.ClosestObstacle))));
                        if (e.Key == Key.W)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            //Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        }

                        else if (e.Key == Key.S)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        }

                        else if (e.Key == Key.A)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        }

                        else if (e.Key == Key.D)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        }
                    }

                    else if (Canvas.GetLeft(character) == Canvas.GetRight(GenObstacle.ClosestObstacle))//going left
                    {
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetLeft(character) + " obs " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle))));
                        if (e.Key == Key.W)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        }

                        else if (e.Key == Key.S)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        }

                        else if (e.Key == Key.A)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            //Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        }

                        else if (e.Key == Key.D)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        }

                        
                    }
                    else
                    {
                        if (e.Key == Key.W)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                        }
                        else if (e.Key == Key.S)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                        }
                        else if (e.Key == Key.A)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                        }
                        else if (e.Key == Key.D)
                        {
                            bit.BeginInit();
                            bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                            bit.EndInit();

                            character.Source = bit;
                            Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                        }
                    }
                }
            }

            else
            {
                if (e.Key == Key.W)
                {
                    bit.BeginInit();
                    bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                    bit.EndInit();

                    character.Source = bit;
                    Canvas.SetTop(character, Canvas.GetTop(character) - 10);
                }
                else if (e.Key == Key.S)
                {
                    bit.BeginInit();
                    bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                    bit.EndInit();

                    character.Source = bit;
                    Canvas.SetTop(character, Canvas.GetTop(character) + 10);
                }
                else if (e.Key == Key.A)
                {
                    bit.BeginInit();
                    bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTLEFT.png", UriKind.Relative);
                    bit.EndInit();

                    character.Source = bit;
                    Canvas.SetLeft(character, Canvas.GetLeft(character) - 10);
                }
                else if (e.Key == Key.D)
                {
                    bit.BeginInit();
                    bit.UriSource = new Uri(@"..\..\Object Model\MOVEMENTRIGHT.png", UriKind.Relative);
                    bit.EndInit();

                    character.Source = bit;
                    Canvas.SetLeft(character, Canvas.GetLeft(character) + 10);
                }
            }
            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);//setting right and bottom of character
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);
        }


        private void TraverseCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\GUY.png", UriKind.Relative);
            bit.EndInit();

            if (e.Key == Key.W)
            {
                character.Source = bit;
            }
            else if (e.Key == Key.S)
            {
                character.Source = bit;
            }
            else if (e.Key == Key.A)
            {
                character.Source = bit;
            }
            else if (e.Key == Key.D)
            {
                character.Source = bit;
            }
        }

        
        private void CanvasInitialized(object sender, EventArgs e)//allows the canvas to take input which allows things like image movement
        {/*<Problem> The ObstacleAbstractFactory feels like a decorator somewhat />*/

            /*<Note> For those planning to use the  />*/
            //Image img = new Image();
            BitmapImage bit = new BitmapImage();
            //GenObstacle obs = new Wall(character, canvas);
            MakeObstacle make = new MakeObstacle();

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/ROAD.png", UriKind.RelativeOrAbsolute);
            bit.EndInit();

            /*<Fix> Added the file and contents of the file to the project. />*/

            road.Source = bit;
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall1);//gotta open the new graphics in VS before they will work properly
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall2);
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall3);
            make.MakeItem(character, canvas, @"../../Object Model/GUY.png", item1);
            //make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall4);

            canvas.Focusable = true;
            canvas.Focus();

        }
    }
}

/*plan: can use canvas.Left and canvas.Bottom to get the area of an element if i need to check if the character tries to walk over a wall. Perhaps can use threading to do this check.*/
/*<Problems> The program could run into threading problems due running threads on multiple obstacles for checking hit detection. Might have to look into another solution </Problem>*/
/*<Note> Might be able to use the decorator and wrap the walls in a hit box for hit detection</Note>*/