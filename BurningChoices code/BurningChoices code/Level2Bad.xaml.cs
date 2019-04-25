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
    /// Interaction logic for Level2Bad.xaml
    /// </summary>
    public partial class Level2Bad : Window
    {
        Story GoodStory;
        ItemCollection CollectItm;
        Inventory observe;
        MakeObstacle make;
        KeyPresses move;
        bool LevelFinished = false;
        public bool IsLevelFinished { get { return LevelFinished; } }

        public Level2Bad()
        {
            
            GoodStory = new Story();
            CollectItm = new ItemCollection();
            observe = new Inventory(CollectItm);
            make = new MakeObstacle();
            move = new KeyPresses();
            
            GoodStory.AddIntro("<LevelIntro>Narrator: Since Xavier wanted to be a murderer, he was sent straight to Hell and had no choice in the matter. " + 
                "Xavier noticed what appeared to be a demon trying to get his attention so Xavier approaches him.");
            GoodStory.AddIntro("<CharacterIntro>Demon: Hey there, welcome to Hell! It’s not too bad here, just a little hot every once in a while. " +
                "You came at the right time! Satan has decided to host a special event to make sure we have fun down here in Hell! " + 
                "In this event there is the option to try and steal the throne. Now, I know this sounds crazy, but no one has signed up for some reason, so you’d be the first! " + 
                "This task may sound daunting or impossible because what can a small guy like you do to overthrow the ruler of hell. Well it just so happens Satan was feeling extra " +
                "giddy today. He wanted me to tell one individual about a secret scepter that will allow the wielder sole dominion over the residents of Hell including Satan himself. Chances are " +
                "Satan wanted me to do this, so that you will get your hopes up and ultimately fail all the while he gets to watch and laugh. I happen to not like Satan for reasons i'll " +
                "explain later. I will tell you that the scepter is split into three parts and each part is hidden in certain parts of Hell. I will give you \"The Sight\" so that you will " +
                "know where to go to collect each part; however, If you don't like the first option you could always try to become the new right hand man! " +
                "I was already kicked out of the running for wasting water. That's why I don't like him. It's pretty petty I know.");
            GoodStory.AddIntro("<CharacterIntro>Narrator: Xavier is faced with  some hard choices, but he is quite arrogant and thus decides to take on Satan.");

            InitializeComponent();
        }

        private void HellCanvas_Initialized(object sender, EventArgs e)
        {
            BitmapImage img = new BitmapImage();

            img.BeginInit();
            img.UriSource = new Uri("../../Object Model/MainCharacter.png", UriKind.Relative);
            img.EndInit();

            MainCharacter.Source = img;

            HellCanvas.Focusable = true;
            HellCanvas.Focus();

            //GenObstacle.GenObs.Clear();
            make.MakeDoor(MainCharacter, HellCanvas, "", WallNorth);
            make.MakeDoor(MainCharacter, HellCanvas, "", WallEast);
            make.MakeDoor(MainCharacter, HellCanvas, "", WallSouth);
            make.MakeDoor(MainCharacter, HellCanvas, "", DoorWest);
            make.MakeNPC(MainCharacter, HellCanvas, "../../Object Model/Demon.png", DemonCharacter);

            move.ConnectCharacter_and_Canvas(MainCharacter, HellCanvas);
        }

        private void HellCanvas_keyDown(object sender, KeyEventArgs e)//controls the movement of the character
        {
            //KeyPresses move = new KeyPresses();

            GenObstacle.CollisionCheck();
            GenObstacle obs = GenObstacle.ClosestElement();

            if (GoodStory.OccuredOnce != true)
            {
                GoodStory.PrintLevelIntro(StoryBox);
            }
                

            if (obs.CollisionStatus)
            {
                
                if (obs is NPC)
                {
                    if(GoodStory.ShouldContinue == false)
                    {
                        GoodStory.PrintConversation(StoryBox);
                        GoodStory.ShouldContinue = true;
                        LevelFinished = true;
                    }
                    move.MoveFreely(e);
                }

                else if (obs is Door)
                {
                    if (GoodStory.ShouldContinue)
                    {
                        obs.Clear();
                        this.Close();
                    }
                    move.MoveFreely(e);
                }
            }

            else
            {
                move.MoveFreely(e);
            }

            Canvas.SetRight(MainCharacter, Canvas.GetLeft(MainCharacter) + MainCharacter.Width);//setting right and bottom of character
            Canvas.SetBottom(MainCharacter, Canvas.GetTop(MainCharacter) + MainCharacter.Height);
        }

        private void HellCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\MainCharacter.png", UriKind.Relative);
            bit.EndInit();
            MainCharacter.Source = bit;
        }

        private void HellInventory_Initialized(object sender, EventArgs e)
        {
            BitmapImage bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/money.png", UriKind.Relative);
            bit.EndInit();

            Image img = new Image();
            img.Source = bit;

            HellInventory.ShowGridLines = true;//shows gridlines
            ColumnDefinition colDef1 = new ColumnDefinition();//defines one column

            HellInventory.ColumnDefinitions.Add(colDef1);//Gives the grid the column

            RowDefinition rowDef1 = new RowDefinition();//Instantiates 3 rows
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            HellInventory.RowDefinitions.Add(rowDef1);//Give my grid three rows
            HellInventory.RowDefinitions.Add(rowDef2);
            HellInventory.RowDefinitions.Add(rowDef3);

            Grid.SetColumnSpan(img, 1);
            Grid.SetRow(img, 0);
            HellInventory.Children.Add(img);
        }
    }
}
