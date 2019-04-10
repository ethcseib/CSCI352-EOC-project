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

        public Inventory(ItemCollection sub, Grid grd)//was protected
        {
            this.sub = sub;
            this.sub.Attach(this);
            this.grd = grd;
            row = 0;
        }

        public void Update(Subject sub)
        {
            if(this.sub == sub)
            {
                img = this.sub.GetItem;
                InventoryPlacement();
                //do something
            }
        }

        void InventoryPlacement()
        {
            if (row < 4)
            {
                Grid.SetColumnSpan(img, 1);
                Grid.SetRow(img, row);
                grd.Children.Add(img);
                row++;
            }
            else
                MessageBox.Show("ERROR: Too many items collected there is no more inventory space.");
            //I believe this will place items collected to the grid
        }
    }
}
