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
            Level2TridentPieces2And3 len = new Level2TridentPieces2And3();
            len.ShowDialog();

            MainMenu win = new MainMenu();
            bool IsGoodEnding = false;
            bool NewGame = false;
            int LevelNumber = 1;

            win.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            win.ShowDialog();

            if(win.Choice == 0)
            {
                NewGame = true;

                MainWindow windoe = new MainWindow();

                windoe.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                windoe.ShowDialog();
                
                if(windoe.IsLevelFinished)
                    LevelNumber++;
            }

            else if(win.Choice == 1)
            {
                //resume where the player left off
            }

            if(LevelNumber == 2)
            {
                Level2Bad level = new Level2Bad();
                level.ShowDialog();

                if(level.IsLevelFinished)
                    LevelNumber++;
                
            }

            if(LevelNumber == 3)
            {
                Level2Trident1 level = new Level2Trident1();
                level.ShowDialog();

                if (level.IsLevelFinished)
                {
                    LevelNumber++;
                }
            }

            if(LevelNumber == 4)
            {
                Level2TridentPieces2And3 level = new Level2TridentPieces2And3();
                level.ShowDialog();

                if (level.IsLevelFinished)
                {
                    LevelNumber++;
                }
            }
        }

    }
}
