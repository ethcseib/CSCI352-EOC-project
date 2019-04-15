using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BurningChoices_code
{
    abstract class Subject
    {
        protected Observer obs;

        public Subject()
        {

        }

        public void Attach(Observer obs)
        {
            this.obs = obs;
        }

        public void Detach()
        {
            this.obs = null;
        }

        public void Notify()
        {
            obs.Update(this);
        }
    }

    class ItemCollection : Subject
    {
        Image item;
        public Image GetItem
        {
            get { return item; }
        }

        public ItemCollection()
        {

        }

        public void Collect(Image item)
        {
            this.item = item;
            //MessageBox.Show("Collected");
            //item.Remove(item);
            

            Notify();   
        }
    }
}
