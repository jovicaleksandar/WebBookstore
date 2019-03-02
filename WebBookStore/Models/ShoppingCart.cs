using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItem> items { get; set; }
        public double Total
        {
            get
            {
                double retVal = 0;
                foreach (ShoppingCartItem sci in items)
                    retVal += sci.total;

                return retVal;
            }
        }

        public ShoppingCart()
        {
            this.items = new List<ShoppingCartItem>();
        }

        public void AddItem(ShoppingCartItem item)
        {
            items.Add(item);
        }
    }
}