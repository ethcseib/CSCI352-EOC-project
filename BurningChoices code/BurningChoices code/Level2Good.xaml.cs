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
    /// Interaction logic for Level2Good.xaml
    /// </summary>
    
    public partial class Level2Good : Window
    {
        Story stor;
        public Level2Good()
        {
            stor = new Story();
            InitializeComponent();
        }

        private void CanvasLoaded(object sender, RoutedEventArgs e)
        {
            Level2Canvas.Focusable = true;
            Level2Canvas.Focus();

            MakeObstacle make = new MakeObstacle();
            BitmapImage bit = new BitmapImage();
            
            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            character.Source = bit;

            bit = new BitmapImage();
            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/SECOND.png", UriKind.Relative);
            bit.EndInit();
            house.Source = bit;

            stor.AddIntro("Narrator: Due to his heartlessness the car exploded. The explosion sent shrapnell and debris everywhere. Xzavier found this out the hard way.");
            stor.AddIntro("Xzavier: AAAGGGHH!");
            stor.AddIntro("Xzavier: What is this? Metal? What?");
            stor.AddIntro("Narrator: Within seconds Xzavier bled out and died.");
            stor.AddDialogue("Demon: Hey! Come here!");
            stor.AddDialogue("Demon: Hello newbie. Welcome to Hell!");
            stor.AddDialogue("Demon: You died at the right time!");
            stor.AddDialogue("Xzavier: Died?!");
            stor.AddDialogue("Demon: Yep! Now back to what I was saying. Satan has gotten bored with the torturing of condemned souls and having Hitler pick out nice and plump pineapples, " +
                "so he has allowed the underworlders to challenge him for the throne!");
            //make.MakeNPC(character, Level2Canvas, @"../../Object Model/Money.png", NPC1);

            stor.ShouldContinue = false;
        }
        
        private void TraverseCanvas_KeyDown(object sender, KeyEventArgs e)
        {
            
            PlayerMovement move = new PlayerMovement(character, Level2Canvas);
            //MessageBox.Show(Convert.ToString(stor.ShouldContinue));
            //if(stor.ShouldContinue == false)
            //{
                stor.ShouldContinue = true;
                stor.PrintConversation();
            
            //GenObstacle.CollisionCheck();
            //GenObstacle obs = GenObstacle.ClosestElement();

            //MessageBox.Show("Uwu i'm a talking pile of money, and i'm here to tell you in a spooky voice that the game isn't finished yet. Spooooky.");
            /*if(obs is NPC)
            {
                
            }*/
            move.MoveFreely(e);


        }

        private void TraverseCanvas_KeyUp(object sender, KeyEventArgs e)
        {
            BitmapImage bit = new BitmapImage();

            bit.BeginInit();
            bit.UriSource = new Uri(@"../../Object Model/MainCharacter.png", UriKind.Relative);
            bit.EndInit();

            character.Source = bit;
        }
    }
}
