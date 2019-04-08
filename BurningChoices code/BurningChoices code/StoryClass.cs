using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BurningChoices_code
{
    class StoryClass
    {
        int access;
        List<string> dialogue;
        List<string> intro;

        public StoryClass()
        {
            access = 0;
            dialogue = new List<string>();
            intro = new List<string>();
        }

        public void AddIntro(string str)
        {
            intro.Add(str);
        }

        public void AddDialogue(string convo)
        {
            dialogue.Add(convo);
        }

        public void PrintConversation()
        {
            if(access == 0)
            {
                access++;

                foreach(string x in intro)
                {
                    MessageBox.Show(x);
                    System.Threading.Thread.Sleep(750);
                }
            }
            else
            {
                foreach(string str in dialogue)
                {
                    MessageBox.Show(str);
                }
            }
        }
    }
}
