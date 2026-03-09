using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public int Copies { get; set; }
        public string Department { get; set; }
        public string Course { get; set; }
        public Book() { 
            Copies = 3;
            Department = "";
            Course = "";
        }
    }
}
