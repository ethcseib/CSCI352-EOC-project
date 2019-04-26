/*Description: Player makes their second choice about which way the story will go.*/
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
        Story BadStory;
        ItemCollection CollectItm;
        Inventory observe;
        MakeObstacle make;
        KeyPresses move;
        bool LevelFinished = false;
        bool GoodEnding = false;
        public bool IsLevelFinished { get { return LevelFinished; } }
        public bool IsGoodEnding { get { return GoodEnding; } }

        public Level2Bad()
        {
            GoodStory = new Story();
            BadStory = new Story();
            CollectItm = new ItemCollection();
            observe = new Inventory(CollectItm);
            make = new MakeObstacle();
            move = new KeyPresses();
            
            GoodStory.AddIntro("<LevelIntro>Narrator: Since Xavier wanted to be a murderer, he was sent straight to Hell and had no choice in the matter. " + 
                "Xavier noticed what appeared to be a demon trying to get his attention so Xavier approaches him.");
            GoodStory.AddIntro("<CharacterIntro>Demon: You came at the right time! Satan holds special events to make sure we always have fun down here! This week there is " +
                "the option to try and steal the throne. Now, I know this sounds crazy, but no one has signed up for some reason, so you’d be the first! Other than that, " +
                "you could become the new right hand man! I was kicked out of the running for wasting water. If you wish to do this then take this fan. Then go and collect ice and water. " +
                "Take them to Satan.");
            GoodStory.AddIntro("<CharacterIntro>Narrator: Xavier is faced with some hard choices, but he is quite arrogant and thus decides to take on Satan.");

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

            make.MakeDoor(MainCharacter, HellCanvas, "", WallNorth);
            make.MakeDoor(MainCharacter, HellCanvas, "", WallEast);
            make.MakeDoor(MainCharacter, HellCanvas, "", WallSouth);
            make.MakeDoor(MainCharacter, HellCanvas, "", DoorWest);
            make.MakeNPC(MainCharacter, HellCanvas, "../../Object Model/Demon.png", DemonCharacter);

            move.ConnectCharacter_and_Canvas(MainCharacter, HellCanvas);
        }

        private void HellCanvas_keyDown(object sender, KeyEventArgs e)
        {
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
                        GoodEnding = true;
                        make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/Fan.png", Fan);
                    }
                    move.MoveFreely(e);
                }

                else if(obs is Item)
                {
                    
                    HellCanvas.Children.Remove(GenObstacle.ClosestObstacle);

                    CollectItm.Collect(GenObstacle.ClosestObstacle);
                    obs.Remove(obs);

                    BadStory.ShouldContinue = true;
                    GoodEnding = false;
                }

                else if (obs is Door)
                {
                    if (GoodEnding == true || GoodEnding == false)
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

            Canvas.SetRight(MainCharacter, Canvas.GetLeft(MainCharacter) + MainCharacter.Width);
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
            observe.Connect(HellInventory);
            HellInventory.ShowGridLines = true;
            ColumnDefinition colDef1 = new ColumnDefinition();

            HellInventory.ColumnDefinitions.Add(colDef1);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            HellInventory.RowDefinitions.Add(rowDef1);
            HellInventory.RowDefinitions.Add(rowDef2);
            HellInventory.RowDefinitions.Add(rowDef3);
        }
    }
}
