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
    /// Interaction logic for Level2BadEnding.xaml
    /// </summary>
    public partial class Level2BadEnding : Window
    {
        MakeObstacle make;
        ItemCollection CollectItm;
        Inventory observe;
        Story BadStory;
        KeyPresses move;
        bool GameBeaten = false;
        public bool IsGameBeaten { get { return GameBeaten; } }

        public Level2BadEnding()
        {
            make = new MakeObstacle();
            CollectItm = new ItemCollection();
            observe = new Inventory(CollectItm);
            BadStory = new Story();
            move = new KeyPresses();
            
            InitializeComponent();
        }

        private void HellCanvas_Initialized(object sender, EventArgs e)
        {
            HellCanvas.Focusable = true;
            HellCanvas.Focus();

            StoryBox.Focusable = false;

            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            MainCharacter.Source = bit;

            bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/SatanicCircle.png", UriKind.Relative);
            bit.EndInit();

            SatanicCircle.Source = bit;

            make.MakeDoor(MainCharacter, HellCanvas, "", Door1);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door2);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door3);
            make.MakeDoor(MainCharacter, HellCanvas, "", Door4);
            make.MakeNPC(MainCharacter, HellCanvas, "../../Object Model/devil.png", Satan);
            make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/Water.png", water);
            make.MakeItem(MainCharacter, HellCanvas, "../../Object Model/Ice.png", ice);

            move.ConnectCharacter_and_Canvas(MainCharacter, HellCanvas);

            BadStory.AddIntro("<LevelIntro>Narrator: Now all Xavier has to do is collect the ice and the water and talk to Satan to start his new-ish life.");
            BadStory.AddIntro("<CharacterIntro>Satan: I see you wish to be my new right hand man. Well your gonna have to work for it! Now give me my water and set up my fan. Maybe in a couple " +
                "thousands years I will consider you. Now LEAVE! Before I get annoyed.");
        }

        private void InvGrd_Initialized(object sender, EventArgs e)
        {
            observe.Connect(InvGrd);

            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri("../../Object Model/Fan.png", UriKind.Relative);
            bit.EndInit();

            Image img = new Image();

            img.Source = bit;
            CollectItm.Collect(img);

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

        private void HellCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            GenObstacle.CollisionCheck();
            GenObstacle obs = GenObstacle.ClosestElement();

            if (BadStory.OccuredOnce != true)
            {
                BadStory.PrintLevelIntro(StoryBox);
            }


            if (obs.CollisionStatus)
            {

                if (obs is NPC)
                {
                    if (BadStory.ShouldContinue == false)
                    {
                        if(observe.Count == 3)
                        {
                            BadStory.PrintConversation(StoryBox);
                            BadStory.ShouldContinue = true;
                            GameBeaten = true;
                        }
                    }
                    move.MoveFreely(e);
                }

                else if (obs is Item)
                {

                    HellCanvas.Children.Remove(GenObstacle.ClosestObstacle);

                    CollectItm.Collect(GenObstacle.ClosestObstacle);
                    obs.Remove(obs);
                }

                else if (obs is Door)
                {
                    if (BadStory.ShouldContinue)
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
    }
}
