using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class ShoppingCartItem
    {
        public Book book { get; set; }
        public int count { get; set; }
        public double total
        {
            get
            {
                return book.price * count;
            }
        }

        public ShoppingCartItem() { }

        public ShoppingCartItem(Book book, int count)
        {
            this.book = book;
            this.count = count;
        }
    }
}