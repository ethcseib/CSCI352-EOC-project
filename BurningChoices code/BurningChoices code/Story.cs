using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BurningChoices_code
{
    class Story
    {
        List<string> dialogue;
        List<string> intro;
        bool cont;
        bool TaskCompleted;

        public bool ShouldContinue { set { cont = value; } get { return cont; } }//set was removed

        public Story()
        {
            TaskCompleted = false;
            dialogue = new List<string>();
            intro = new List<string>();
            cont = false;
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
            /*if (intro.Count == 0 && dialogue.Count == 0)
            {
                MessageBox.Show("What are you still doing here? Leave!");
            }*/

            if(intro.Count != 0)
            {
                cont = true;

                foreach(string x in intro)
                {
                    MessageBox.Show(x);
                }
                intro.Clear();
            }
            else if(cont)
            {
                foreach(string str in dialogue)
                {
                    MessageBox.Show(str);
                    //MessageBox.Show("hi");
                }
                dialogue.Clear();
                //TaskCompleted = true;
            }
        }
    }
}
