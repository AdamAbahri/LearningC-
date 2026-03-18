using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System__Task4_
{
   public class Transaction
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }

        public void Display()
        {
            Console.WriteLine($"Transaction ID: {Id}");
            Console.WriteLine($"Book Title: {BookTitle}");
            Console.WriteLine($"Member Name: {MemberName}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Type: {Type}");
        }
    }
}
