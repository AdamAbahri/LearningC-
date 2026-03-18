using Library_Managment_System__Task4_;
using System;

namespace LibrarySystem
{
    internal class Program
    {
        static void Main(string[] args)
        {

            library library = new library(10, 10, 50);

            Book b1 = new Book(1, "Clean Code", "Robert Martin", 30);
            Book b2 = new Book(2, "Design Patterns", "GoF", 40);
            Book b3 = new Book(3, "C# in Depth", "Jon Skeet", 35);

            library.AddBook(b1);
            library.AddBook(b2);
            library.AddBook(b3);


            Member m1 = new StudentMember(1, "Ahmad", "0599999999");
            Member m2 = new TeacherMember(2, "Dr. Ali", "0598888888");

            library.AddMember(m1);
            library.AddMember(m2);


            bool exit = false;

            while (!exit)
            {

                Console.WriteLine("\n===== Library System =====");
                Console.WriteLine("1 Borrow Book");
                Console.WriteLine("2 Return Book");
                Console.WriteLine("3 Show Transactions");
                Console.WriteLine("4 Compare Members");
                Console.WriteLine("5 Show Borrow Limits");
                Console.WriteLine("6 Exit");

                Console.Write("Choose Option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {

                    case 1:

                        Console.Write("Member Id: ");
                        int memberId = int.Parse(Console.ReadLine());

                        Console.Write("Book Id: ");
                        int bookId = int.Parse(Console.ReadLine());

                        library.BorrowBook(memberId, bookId);

                        break;

                    case 2:

                        Console.Write("Member Id: ");
                        memberId = int.Parse(Console.ReadLine());

                        Console.Write("Book Id: ");
                        bookId = int.Parse(Console.ReadLine());

                        Console.Write("Days Late: ");
                        int days = int.Parse(Console.ReadLine());

                        library.ReturnBook(memberId, bookId, days);

                        break;

                    case 3:

                        library.PrintTransactions();

                        break;

                    case 4:

                        if (m1 > m2)
                            Console.WriteLine($"{m1.Name} borrowed more books");
                        else
                            Console.WriteLine($"{m2.Name} borrowed more books");

                        Console.WriteLine($"Total Borrowed by both: {m1 + m2}");

                        break;

                    case 5:

                        Console.WriteLine($"{m1.Name} Limit = {m1.GetMaxBorrowLimit()}");
                        Console.WriteLine($"{m2.Name} Limit = {m2.GetMaxBorrowLimit()}");

                        break;

                    case 6:

                        exit = true;
                        break;

                }

                Console.WriteLine($"\nTotal Borrowed Books In Library = {library.TotalBorrowedBooks}");

            }

        }
    }
}