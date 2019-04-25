using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BurningChoices_code
{
    interface Observer
    {
        void Update(Subject sub);
    }

    class Inventory : Observer
    {
        int row;
        ItemCollection sub;
        Image img;
        Grid grd;
        public int test = 0;//remove later

        public int Count { get { return row; } }

        public Inventory(ItemCollection sub)//was protected
        {
            this.sub = sub;
            this.sub.Attach(this);
            row = 0;
        }

        public void Connect(Grid grd)
        {
            if(this.grd == null)
            this.grd = grd;
        }

        public void Update(Subject sub)//gets an update the inventory
        {
            if(this.sub == sub)
            {
                img = this.sub.GetItem;//automatic step over for some reason
                InventoryPlacement();
            }
        }

        void InventoryPlacement()//places in the inventory
        {
            if (row < 3)
            {
                Grid.SetColumnSpan(img, 1);
                Grid.SetRow(img, row);
                grd.Children.Add(img);
                
                row++;
            }
            else
                row++;
        }

        public void Clear()
        {
            grd.Children.Clear();
        }
    }
}
