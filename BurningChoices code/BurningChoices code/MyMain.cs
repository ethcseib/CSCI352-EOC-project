using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BurningChoices_code
{
    class MyMain
    {
        [STAThreadAttribute]
        static void Main()
        {
            /*<Summary> Our created main so that we are able to control the flow/ Level progression. Our game's main menu will be opened and then the player will select a menu item />*/

            MainMenu win = new MainMenu();
            bool IsGoodEnding = false;
            int LevelNumber = 1;//keeps track of player level progression
            bool GameBeaten = false;
            string SavedGame = "";

            win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            win.ShowDialog();

            if(win.Choice == 0)//new game
            {
                /*<Summary> Opens a new game starting from the beginning />*/

                MainWindow windoe = new MainWindow();

                windoe.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                windoe.ShowDialog();

                if (windoe.IsGameBeaten)
                {
                    GameBeaten = windoe.IsGameBeaten;
                }
                else if(windoe.IsLevelFinished)
                    LevelNumber++;
            }

            else if(win.Choice == 1)//Resume game
            {
                /*<Summary> The user wishes to load a game />*/

                SavedGame = System.IO.File.ReadAllText("../../Saved Game/SaveGame1.txt");
                SavedGame = SavedGame.Remove(0, 20);

                if(SavedGame == "MainWindow")
                {
                    MainWindow wn = new MainWindow();
                    wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    wn.ShowDialog();
                }
                else if (SavedGame == "Level2Bad")
                {
                    Level2Bad wn = new Level2Bad();
                    wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    wn.ShowDialog();
                }
                else if (SavedGame == "Level2Trident1")
                {
                    Level2Trident1 wn = new Level2Trident1();
                    wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    wn.ShowDialog();
                }
                else if (SavedGame == "Level2TridentPieces2And3")
                {
                    Level2TridentPieces2And3 wn = new Level2TridentPieces2And3();
                    wn.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    wn.ShowDialog();
                }
            }

            if(LevelNumber == 2)
            {
                /*<Summary> The user chose to quit the game from the main menu and game />*/
                Level2Bad level = new Level2Bad();

                if(IsGoodEnding == false)
                {
                    level.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    level.ShowDialog();
                }

                IsGoodEnding = level.IsGoodEnding;

                if (level.IsLevelFinished)
                    LevelNumber++;
            }

            if(LevelNumber == 3)
            {
                bool LevelFinished = false;   
                

                if(IsGoodEnding == true)
                {
                    Level2Trident1 level = new Level2Trident1();
                    level.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    level.ShowDialog();
                    LevelFinished = level.IsLevelFinished;
                }
                else if(IsGoodEnding == false)
                {
                    Level2BadEnding lev = new Level2BadEnding();
                    lev.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    lev.ShowDialog();
                    GameBeaten = lev.IsGameBeaten;
                }

                if (LevelFinished)
                {
                    LevelNumber++;
                }
            }

            if(LevelNumber == 4)
            {
                Level2TridentPieces2And3 level = new Level2TridentPieces2And3();
                level.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                level.ShowDialog();

                if (level.IsLevelFinished)
                {
                    GameBeaten = level.IsGameBeaten;
                }
            }

            if (GameBeaten)
            {
                MessageBox.Show("Congratulations on beating the game!");
            }
        }
    }
}
