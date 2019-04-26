/*Description: This is part of our observer pattern that was used for the inventory system. This is the Observer portion */ 
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
        /*<Summary> This is the inventory that stores items collected by the player. It connects to a Grid control for displaying />*/

        int row;
        ItemCollection sub;
        Image img;
        Grid grd;

        public int Count { get { return row; } }

        public Inventory(ItemCollection sub)//was protected
        {
            this.sub = sub;
            this.sub.Attach(this);
            row = 0;
        }

        public void Connect(Grid grd)//Connects the object to a Grid
        {
            if(this.grd == null)
            this.grd = grd;
        }

        public void Update(Subject sub)//gets and update the inventory
        {
            if(this.sub == sub)
            {
                img = this.sub.GetItem;//automatic step over for some reason
                InventoryPlacement();
            }
        }

        void InventoryPlacement()//places item in the inventory
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

        public void Clear()//clears the inventory of items
        {
            row = 0;
            grd.Children.Clear();
        }
    }
}
