using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System__Task4_
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public bool isBorrowed { get; set; }

            public Book(int id, string title, string author, float price)
            {
                Id = id;
                Title = title;
                Author = author;
                Price = price;
                isBorrowed = false;
        }
        public void DisplayBook()
        {
            Console.WriteLine("Book Details:");
                Console.WriteLine($"Id: {Id}");
                Console.WriteLine($"Title: {Title}");
                Console.WriteLine($"Author: {Author}");
                Console.WriteLine($"Price: ${Price}");
                Console.WriteLine($"Is Borrowed: {(isBorrowed ? "Available" : "UnAvailable")}");
        }
    }
}
