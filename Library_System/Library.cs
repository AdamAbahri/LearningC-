using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_System
{
    public class Library
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public Book[] Books { get; set; }
        public Manager LibraryManager { get; set; }
        public Modes CurrentMode { get; set; }
    }
}
