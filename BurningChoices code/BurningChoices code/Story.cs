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

        public bool ShouldContinue { get { return cont; } set { cont = value; } }

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
            if (TaskCompleted)
            {
                MessageBox.Show("What are you still doing here? Leave!");
            }
            else if(cont == false)
            {
                foreach(string x in intro)
                {
                    MessageBox.Show(x);
                }
            }
            else if(cont)
            {
                foreach(string str in dialogue)
                {
                    MessageBox.Show(str);
                }
                TaskCompleted = true;
            }
        }
    }
}
