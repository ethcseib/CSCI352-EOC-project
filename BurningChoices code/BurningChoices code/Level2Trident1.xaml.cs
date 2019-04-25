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
    /// Interaction logic for Level2Trident1.xaml
    /// </summary>
    public partial class Level2Trident1 : Window
    {
        MakeObstacle make = new MakeObstacle();
        ItemCollection CollectItm;
        Inventory inv;
        KeyPresses press;
        bool LevelFinished;
        Story GoodStory;
        public bool IsLevelFinished { get { return LevelFinished; } }

        public Level2Trident1()
        {
            press = new KeyPresses();
            CollectItm = new ItemCollection();
            inv = new Inventory(CollectItm);
            LevelFinished = false;
            GoodStory = new Story();

            InitializeComponent();
        }

        private void MainCharacter_Initialized(object sender, EventArgs e)
        {
            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            MainCharacter.Source = bit;

            Canvas.SetRight(MainCharacter, Canvas.GetLeft(MainCharacter) + MainCharacter.Width);//setting right and bottom of character
            Canvas.SetBottom(MainCharacter, Canvas.GetTop(MainCharacter) + MainCharacter.Height);

            
        }

        private void HellCanvas_Initialized(object sender, EventArgs e)
        {
            GoodStory.AddIntro("<LevelIntro>Xavier: Well I suppose that is the first piece of the scepter thing that demon was talking about.");
            GoodStory.AddIntro("<CharacterIntro>Xavier: One piece down just two more to go. I guess I should try going down or the the left to find the other pieces.");
            HellCanvas.Focusable = true;
            HellCanvas.Focus();

            //make.MakeWall(MainCharacter, HellCanvas, "../../Object Model/rocks.png", HellRock1);
            make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/T3.png", TridentPiece);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door1);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door2);
            make.MakeWall(MainCharacter, HellCanvas, "", Wall1);
            make.MakeWall(MainCharacter, HellCanvas, "", Wall2);

            press.ConnectCharacter_and_Canvas(MainCharacter, HellCanvas);
        }

        private void HellCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\MainCharacter.png", UriKind.Relative);
            bit.EndInit();
            MainCharacter.Source = bit;
        }

        private void HellCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            GenObstacle.CollisionCheck();
            GenObstacle obs = GenObstacle.ClosestElement();

            if(GoodStory.OccuredOnce != true)
            {
                GoodStory.PrintLevelIntro(StoryBox);
            }

            if (obs.CollisionStatus)
            {
                //MessageBox.Show(Convert.ToString(obs.Count()));
                if (obs.collideable)
                {
                    if (Canvas.GetRight(MainCharacter) == Canvas.GetLeft(GenObstacle.ClosestObstacle))//going right
                    { 
                        press.RestrictRight(e);
                    }

                    else if (Canvas.GetBottom(MainCharacter) == Canvas.GetTop(GenObstacle.ClosestObstacle))//going down
                    {
                        press.RestrictDown(e);
                    }

                    else if (Canvas.GetTop(MainCharacter) == Canvas.GetBottom(GenObstacle.ClosestObstacle))//going up
                    {
                        press.RestrictUp(e);
                        
                    }

                    else if (Canvas.GetLeft(MainCharacter) == Canvas.GetRight(GenObstacle.ClosestObstacle))//going left
                    {
                        press.RestrictLeft(e);
                    }

                    else
                    {
                        press.MoveFreely(e);
                    }
                }
                else if(obs is Item)
                {
                    HellCanvas.Children.Remove(GenObstacle.ClosestObstacle);
                    CollectItm.Collect(GenObstacle.ClosestObstacle);
                    obs.Remove(obs);
                    LevelFinished = true;

                    GoodStory.PrintConversation(StoryBox);
                    GoodStory.ShouldContinue = true;
                    
                }
                else if (obs is Door)
                {
                    if (LevelFinished)
                    {
                        obs.Clear();
                        this.Close();
                    }
                    press.MoveFreely(e);
                }
            }
            else
            {
                press.MoveFreely(e);
            }
            Canvas.SetRight(MainCharacter, Canvas.GetLeft(MainCharacter) + MainCharacter.Width);//setting right and bottom of character
            Canvas.SetBottom(MainCharacter, Canvas.GetTop(MainCharacter) + MainCharacter.Height);
        }

        private void InvGrd_Initialized(object sender, EventArgs e)
        {
            inv.Connect(InvGrd);
            InvGrd.ShowGridLines = true;
            ColumnDefinition colDef1 = new ColumnDefinition();

            InvGrd.ColumnDefinitions.Add(colDef1);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            InvGrd.RowDefinitions.Add(rowDef1);
            InvGrd.RowDefinitions.Add(rowDef2);
            InvGrd.RowDefinitions.Add(rowDef3);
        }

        private void StoryBox_Initialized(object sender, EventArgs e)
        {
            StoryBox.Focusable = false;
        }
    }
}
