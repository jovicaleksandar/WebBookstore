using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookStore.Models
{
    public class Books
    {
        public Dictionary<string, Book> collection { get; set; }
        public List<string> genres { get; set; }

        public Books()
        {
            collection = new Dictionary<string, Book>();
            genres = new List<string>();
            genres.Add("Science");
            genres.Add("Comedy");
            genres.Add("Horror");
        }

        public Books(Dictionary<string, Book> collection)
        {
            this.collection = collection;
        }

        public void AddGenre(string genre)
        {
            foreach(string s in genres)
            {
                if (s == genre)
                    return;
            }

            genres.Add(genre);
        }

        public void DeleteGenre(string genre)
        {
            foreach (string s in genres)
            {
                if (s == genre)
                    genres.Remove(genre);
            }
        }
    }
}