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
        Story GoodStory;
        Story BadStory;
        ItemCollection ItmCollect;
        Inventory observe;
        MakeObstacle make;
        bool LevelFinished;
        KeyPresses move;
        public bool IsLevelFinished { get { return LevelFinished; } }

        public MainWindow()
        {
            move = new KeyPresses();
            GoodStory = new Story();
            BadStory = new Story();
            ItmCollect = new ItemCollection();
            observe = new Inventory(ItmCollect);
            make = new MakeObstacle();
            LevelFinished = false;

            InitializeComponent();
        }

        private void CharacterInitialized(object sender, EventArgs e)
        {
            /*<Summary> establishes the main character model. bitmap.UriSource will have to change depending on where the images are located on the pc. Could change it to "mlg.jpg" if the image
             is moved to the .exe folder </Summary>*/
            
            BitmapImage bitmap = new BitmapImage();//system.Windows.Media.BitmapImage rather than Sytem.Drawing

            bitmap.BeginInit();
            bitmap.UriSource = new Uri(@"..\..\Object Model\MainCharacter.png", UriKind.Relative);//experimenting with file locations so that they can easier access the program
            bitmap.EndInit();

            character.Source = bitmap;

            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);


        }

        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {

            GenObstacle.CollisionCheck();//might look into being able to remove GenObstacle in favor of MakeObstacle or remove it all together
            GenObstacle obs = GenObstacle.ClosestElement();

            if(GoodStory.OccuredOnce != true)
                GoodStory.PrintLevelIntro(StoryBox);

           if (obs.CollisionStatus)
           {
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
                else if(obs is NPC)
                {
                    if(GoodStory.ShouldContinue == false && observe.Count == 0)
                    {
                        GoodStory.PrintConversation(StoryBox);
                        make.MakeItem(character, canvas, @"../../Object Model/Quit.png", bandage1);
                        make.MakeItem(character, canvas, @"../../Object Model/Quit.png", bandage2);
                        make.MakeItem(character, canvas, @"../../Object Model/Quit.png", bandage3);
                        GoodStory.ShouldContinue = true;

                        canvas.Children.Remove(money);
                        
                    }

                    else if(GoodStory.ShouldContinue == true && observe.Count == 3 && GoodStory.IsComplete == false)
                    {
                        GoodStory.PrintConversation(StoryBox);
                        observe.Clear();
                    }

                    move.MoveFreely(e);
                }

                else if(obs is Item)
                {
                    if(GoodStory.ShouldContinue == false && BadStory.IsComplete == false)
                    {
                        BadStory.PrintConversation(StoryBox);
                    }
                   
                    canvas.Children.Remove(GenObstacle.ClosestObstacle);

                    ItmCollect.Collect(GenObstacle.ClosestObstacle);
                    obs.Remove(obs);
                }

                else if(obs is Door)
                {
                    if(GoodStory.IsComplete || BadStory.IsComplete)
                    {
                        obs.Clear();//just added
                        LevelFinished = true;
                        this.Close();
                    }
                    move.RestrictUp(e);//defeats the point of collision checking in a way 
                }
           }
            
            else
            {
                move.MoveFreely(e);
            }

            Canvas.SetRight(character, Canvas.GetLeft(character) + character.Width);//setting right and bottom of character
            Canvas.SetBottom(character, Canvas.GetTop(character) + character.Height);
        }

        private void TraverseCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\MainCharacter.png", UriKind.Relative);
            bit.EndInit();
            character.Source = bit;
        }

        
        private void CanvasInitialized(object sender, EventArgs e)//allows the canvas to take input which allows things like image movement
        {
            
            BitmapImage bit = new BitmapImage();

            GoodStory.AddIntro("<LevelIntro>Narrator: This is a story about a young programmer named Xavier. He is just an average dude trying to make it through the onslaught of job interviews. Today is a special " +
                "day for Xavier for he will be inflicted with a disease known as \"Burning Choices\".");//not a fan of the end of this line
            GoodStory.AddIntro("<LevelIntro>Narrator: While walking home from work Xavier bore witness to a car swerve and crash into a tree.");
            GoodStory.AddIntro("<LevelIntro>As Xavier approached the car he noticed that the person was bleeding and unconcious.");
            GoodStory.AddIntro("<LevelIntro>Xavier: I wonder what happened to her. Was she drunk? Wait! Is that an unusually large amount of money? Should I take it and run? It would be easy no one knows" +
                " I was here, but she could die if I leave them. Perhaps I should help them instead.");
            GoodStory.AddDialogue("Narrator: Xavier did as any person might do.");
            GoodStory.AddIntro("<LevelIntro>Xavier: This could be a once in a lifetime oppurtunity for me!");
            BadStory.AddDialogue("Narrator: Xavier took the money and ran with it.");

            GoodStory.AddIntro("<CharacterIntro>Xavier: Hi im Xavier you are hurt! I'm calling the police.");
            GoodStory.AddIntro("<CharacterIntro>Police: This is the police how may we help you? Just kidding! We are the thought police. We know the situation. Gather three bandages to save their life.");
            
            GoodStory.AddDialogue("Police: Have you found the special trees?");
            GoodStory.AddDialogue("Police: Good good you have just saved this woman's life. I feel some good fortune coming your way sir or madam.");
            GoodStory.AddDialogue("Xavier: It's sir.");
            GoodStory.AddDialogue("Police: Yeah I don't care your services are no longer needed please leave and continue with your life. By please I mean leave before I bring you in for some made " +
                "a thought crime.");
            GoodStory.AddDialogue("Xavier's inner thoughts: I guess I should head NORTH along the road to head home. There's nothing for me here.");

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/FirstMap.png", UriKind.RelativeOrAbsolute);
            bit.EndInit();

            /*<Fix> Added the file and contents of the file to the project. />*/

            road.Source = bit;
            make.MakeItem(character, canvas, @"../../Object Model/MONEY.png", money);
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall1);//gotta open the new graphics in VS before they will work properly
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall2);
            make.MakeWall(character, canvas, @"../../Object Model/Wall.png", wall3);
            make.MakeDoor(character, canvas, "", Door1);
            make.MakeNPC(character, canvas, @"../../Object Model/GUY.png", NPC1);

            canvas.Focusable = true;
            canvas.Focus();

            move.ConnectCharacter_and_Canvas(character, canvas);
        }

        private void GridInitialized(object sender, EventArgs e)
        {
            observe.Connect(InventoryGrid);
            InventoryGrid.ShowGridLines = true;//shows gridlines
            ColumnDefinition colDef1 = new ColumnDefinition();//defines one column

            InventoryGrid.ColumnDefinitions.Add(colDef1);//Gives the grid the column

            RowDefinition rowDef1 = new RowDefinition();//Instantiates 3 rows
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            InventoryGrid.RowDefinitions.Add(rowDef1);//Give my grid three rows
            InventoryGrid.RowDefinitions.Add(rowDef2);
            InventoryGrid.RowDefinitions.Add(rowDef3);
        }
    }
}