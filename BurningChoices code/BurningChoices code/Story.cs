/*Description: Makes creating in game story easier.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BurningChoices_code
{
    class Story
    {
        public List<string> dialogue;
        List<string> intro;
        bool cont;
        bool complete;
        bool good;
        bool occured;
        public bool OccuredOnce { get { return occured; } }
        public bool IsGood { get { return good; } }
        public bool IsComplete { get { return complete; } }
        public bool ShouldContinue { set { cont = value; } get { return cont; } }

        public Story()
        {
            occured = false;
            good = false;
            complete = false;
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

        public void PrintLevelIntro(TextBox box)
        {
            /*<Summary> Prints the intro for every level />*/

            occured = true;
            foreach (string x in intro)
            {
                if (x.Substring(0, 12) == "<LevelIntro>")
                {
                    
                    box.Text += "\n" + x.Remove(0, 12) + "\n";
                    
                }
            }
        }

        public void PrintConversation(TextBox box)
        {
            /*<Summary> Print conversation between characters />*/
            box.Text = "\n";
            
            if(intro.Count != 0)
            {
                cont = true;

                foreach(string x in intro)
                {
                    if(x.Substring(0, 16) == "<CharacterIntro>")
                    {
                        box.Text += x.Remove(0, 16) + "\n";
                    }
                }
                intro.Clear();
            }

            else if(dialogue.Count != 0)
            {
                foreach(string str in dialogue)
                {
                    box.Text += str + "\n";
                }
                complete = true;
                dialogue.Clear();
            }
        }
    }
}
