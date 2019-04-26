/*Description: The last level of the Bad/Good ending where the player takes over hell.*/
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
    /// Interaction logic for Level2TridentPieces2And3.xaml
    /// </summary>
    public partial class Level2TridentPieces2And3 : Window
    {
        MakeObstacle make;
        Inventory inv;
        ItemCollection CollectItm;
        Story GoodStory;
        KeyPresses press;
        bool LevelFinished;
        bool GameBeaten;
        public bool IsLevelFinished { get { return LevelFinished; } }
        public bool IsGameBeaten { get { return GameBeaten; } }

        public Level2TridentPieces2And3()
        {
            make = new MakeObstacle();
            CollectItm = new ItemCollection();
            inv = new Inventory(CollectItm);
            GoodStory = new Story();
            press = new KeyPresses();
            LevelFinished = false;
            GameBeaten = false;

            InitializeComponent();
        }

        private void HellCanvas_Initialized(object sender, EventArgs e)
        {
            GoodStory.AddIntro("<LevelIntro>Xavier: This is it. The last two pieces and then I confront Satan.");
            GoodStory.AddDialogue("Satan: Well Well. I see you have collected all of the pieces to the staff. I geuss this means you rule hell now. If you will head left your prize awaits " +
                "you.");

            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/SatanicCircle.png", UriKind.Relative);
            bit.EndInit();

            SatanicGrid.Source = bit;

            bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            MainCharacter.Source = bit;

            HellCanvas.Focusable = true;
            HellCanvas.Focus();

            make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/T1.png", Trident1);
            make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/T2.png", Trident2);
            make.MakeNPC(MainCharacter, HellCanvas, "../../Object Model/devil.png", Satan);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door1);
            make.MakeWall(MainCharacter, HellCanvas, "", Wall3);
            make.MakeWall(MainCharacter, HellCanvas, "", Wall1);
            make.MakeWall(MainCharacter, HellCanvas, "", Wall2);

            press.ConnectCharacter_and_Canvas(MainCharacter, HellCanvas);

            Canvas.SetRight(MainCharacter, Canvas.GetLeft(MainCharacter) + MainCharacter.Width);//setting right and bottom of character
            Canvas.SetBottom(MainCharacter, Canvas.GetTop(MainCharacter) + MainCharacter.Height);
        }

        private void HellCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            GenObstacle.CollisionCheck();
            GenObstacle obs = GenObstacle.ClosestElement();

            if (GoodStory.OccuredOnce != true)
            {
                GoodStory.PrintLevelIntro(StoryText);
            }

            if (obs.CollisionStatus)
            {
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
                else if(obs is NPC)
                {
                    if (inv.Count == 1)
                    {
                        if(GoodStory.ShouldContinue)
                        {
                            if(GoodStory.IsComplete != true)
                            {
                                GoodStory.PrintConversation(StoryText);
                                LevelFinished = true;
                                GameBeaten = true;
                                
                            }
                                
                        }
                            
                    }
                    press.MoveFreely(e);
                }
                else if (obs is Item)
                {
                    HellCanvas.Children.Remove(GenObstacle.ClosestObstacle);
                    CollectItm.Collect(GenObstacle.ClosestObstacle);
                    obs.Remove(obs);

                    if(inv.Count == 3)
                    {
                        inv.Clear();

                        Image img = new Image();
                        BitmapImage bit = new BitmapImage();

                        bit.BeginInit();
                        bit.UriSource = new Uri("../../Object Model/Trident.png", UriKind.Relative);
                        bit.EndInit();

                        img.Source = bit;
                        CollectItm.Collect(img);
                        GoodStory.ShouldContinue = true;
                    }
                }
                else if(obs is Door)
                {
                    if (GoodStory.IsComplete)
                    {
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

        private void HellCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\MainCharacter.png", UriKind.Relative);
            bit.EndInit();
            MainCharacter.Source = bit;
        }

        private void InvGrd_Initialized(object sender, EventArgs e)
        {
            BitmapImage bit = new BitmapImage();
            Image img = new Image();

            bit.BeginInit();
            bit.UriSource = new Uri(@"..\..\Object Model\T3.png", UriKind.Relative);
            bit.EndInit();

            img.Source = bit;

            inv.Connect(InvGrd);
            InvGrd.ShowGridLines = true;

            CollectItm.Collect(img);
            ColumnDefinition colDef1 = new ColumnDefinition();

            InvGrd.ColumnDefinitions.Add(colDef1);

            RowDefinition rowDef1 = new RowDefinition();
            RowDefinition rowDef2 = new RowDefinition();
            RowDefinition rowDef3 = new RowDefinition();

            InvGrd.RowDefinitions.Add(rowDef1);
            InvGrd.RowDefinitions.Add(rowDef2);
            InvGrd.RowDefinitions.Add(rowDef3);
        }
    }
}
