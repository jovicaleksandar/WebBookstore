using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class Book
    {
        public string name { get; set; }
        public double price { get; set; }
        public string genre { get; set; }

        public Book() { }

        public Book(string name, double price, string genre)
        {
            this.name = name;
            this.price = price;
            this.genre = genre;
        }
    }
}