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
        StoryClass story = new StoryClass();

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
            PlayerMovement move = new PlayerMovement(character, canvas);

            GenObstacle.CollisionCheck();//might look into being able to remove GenObstacle in favor of MakeObstacle or remove it all together
            GenObstacle obs = GenObstacle.ClosestElement();

            if (obs.CollisionStatus)
           {
                if (obs is NPC)
                {
                    
                    story.PrintConversation();
                    move.MoveFreely(e);
                }

                //MessageBox.Show("X " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle)) + " Y " + Convert.ToString(Canvas.GetTop(GenObstacle.ClosestObstacle)));
                if (obs.collideable)
                {
                    if (Canvas.GetRight(character) == Canvas.GetLeft(GenObstacle.ClosestObstacle))//going right
                    { //MessageBox.Show("Character " + Convert.ToString(Canvas.GetRight(character) + " obs " + Convert.ToString(Canvas.GetLeft(GenObstacle.ClosestObstacle))));
                        move.RestrictRight(e);
                    }

                    else if (Canvas.GetBottom(character) == Canvas.GetTop(GenObstacle.ClosestObstacle))//going down
                    {
                        move.RestrictDown(e);
                    }

                    else if (Canvas.GetTop(character) == Canvas.GetBottom(GenObstacle.ClosestObstacle))//going up
                    {
                        move.RestrictUp(e);
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetTop(character) + " obs " + Convert.ToString(Canvas.GetBottom(GenObstacle.ClosestObstacle))));
                    }

                    else if (Canvas.GetLeft(character) == Canvas.GetRight(GenObstacle.ClosestObstacle))//going left
                    {
                        move.RestrictLeft(e);
                        //MessageBox.Show("Character " + Convert.ToString(Canvas.GetLeft(character) + " obs " + Convert.ToString(Canvas.GetRight(GenObstacle.ClosestObstacle))));
                    }

                    else
                    {
                        move.MoveFreely(e);
                    }
                }

                else if(obs is Item)//type checking
                {
                    canvas.Children.Remove(GenObstacle.ClosestObstacle);
                    
                    obs.Remove(obs);//quick and dirty. Needs improvement.
                }
                else if(obs is Door)
                {
                    MessageBox.Show("door");
                    /*MakeObstacle make = new MakeObstacle();
                    Publisher pub = new Publisher();
                    //make.MakeDoor(character, canvas, null, Door1, pub);
                    pub.DoSomething();*/
                    //raise an event here that will change the level
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
        {

            BitmapImage bit = new BitmapImage();
            MakeObstacle make = new MakeObstacle();

            story.AddIntro("Hi im James you are hurt! I'm calling the police.");
            story.AddIntro("This is the police how may we help you? Just kidding! We are the thought police. We know the situation. Gather three bandages to save their life.");

            story.AddDialogue("Have you found the bandages?");
            story.AddDialogue("Good good you have just saved this woman's life. I feel some good fortune coming your way sir or madam.");
            story.AddDialogue("It's sir.");
            story.AddDialogue("Yeah I don't care your services are no longer needed please leave and continue with your life. By please I mean leave before I bring you in for some made " +
                "up thought crime.");

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/ROAD.png", UriKind.RelativeOrAbsolute);
            bit.EndInit();

            /*<Fix> Added the file and contents of the file to the project. />*/

            //road.Source = bit;
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall1);//gotta open the new graphics in VS before they will work properly
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall2);
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall3);
            make.MakeDoor(character, canvas, "", Door1);
            make.MakeItem(character, canvas, @"../../Object Model/GUY.png", item1);
            make.MakeNPC(character, canvas, @"../../Object Model/GUY.png", NPC1);

            canvas.Focusable = true;
            canvas.Focus();

        }
    }
}

/*plan: can use canvas.Left and canvas.Bottom to get the area of an element if i need to check if the character tries to walk over a wall. Perhaps can use threading to do this check.*/
/*<Problems> The program could run into threading problems due running threads on multiple obstacles for checking hit detection. Might have to look into another solution </Problem>*/
/*<Note> Might be able to use the decorator and wrap the walls in a hit box for hit detection</Note>*/