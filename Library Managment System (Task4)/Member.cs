using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Managment_System__Task4_
{
    public abstract class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Book[] BorrowedBooks;
        public int BorrowIndex { get; set; }
        public abstract int GetMaxBorrowLimit();

        public Member(int id, string name, string phone)
        {
            Id = id;
            Name = name;
            Phone = phone;
            BorrowedBooks = new Book[GetMaxBorrowLimit()];
            BorrowIndex = 0;
        }
        public virtual void BorrowBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book is not Found ! ");
                return;
            }
            if (book.isBorrowed)
            {
                Console.WriteLine($"Book `{book.Title}` already Borrowed !");
                return;
            }
            if (BorrowIndex >= GetMaxBorrowLimit())
            {
                Console.WriteLine($"You Have reached max limit of Book {GetMaxBorrowLimit()}");
                return;
            }
            BorrowedBooks[BorrowIndex] = book;
            BorrowIndex++;
            book.isBorrowed = true;

            Console.WriteLine($"Book `{book.Title}` Borrowed Successfully !");
            Console.WriteLine($"Count of Borrowed Books : {BorrowIndex}/{GetMaxBorrowLimit()}");

        }
        public virtual void ReturnBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book is not Found ! ");
                return;
            }
            bool found = false;
            for (int i = 0; i < BorrowIndex; i++)
            {
                if (BorrowedBooks[i] != null && BorrowedBooks[i].Id == book.Id)
                {
                    book.isBorrowed = false;
                    for (int j = i; j < BorrowIndex - 1; j++)
                    {
                        BorrowedBooks[j] = BorrowedBooks[j + 1];
                    }
                    BorrowedBooks[BorrowIndex - 1] = null;
                    BorrowIndex--;
                    found = true;
                    Console.WriteLine($"Book `{book.Title}` Returned Successfully !");
                    Console.WriteLine($"Count of Borrowed Books : {BorrowIndex}/{GetMaxBorrowLimit()}");
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine($"Book {book.Title} is not Borrowed to be returned !");
            }
        }
        public static bool operator >( Member m1, Member m2)
        {
            return m1.BorrowIndex > m2.BorrowIndex;
        }
        public static bool operator <(Member m1, Member m2)
        {
            return m1.BorrowIndex < m2.BorrowIndex;
        }
        public static int operator +(Member m1, Member m2)
        {
            return m1.BorrowIndex + m2.BorrowIndex;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine("\n");
            Console.WriteLine($"  Member ID    : {Id}");
            Console.WriteLine($"  Name         : {Name}");
            Console.WriteLine($"  Phone        : {Phone}");
            Console.WriteLine($"  Type         : {GetType().Name}");
            Console.WriteLine($"  Borrowed     : {BorrowIndex}/{GetMaxBorrowLimit()} books");

            if (BorrowIndex > 0)
            {
                Console.WriteLine("  Borrowed Books:");
                for (int i = 0; i < BorrowIndex; i++)
                {
                    if (BorrowedBooks[i] != null)
                    {
                        Console.WriteLine($"    {i + 1}. {BorrowedBooks[i].Title}");
                    }
                }

            }
            else
            {
                Console.WriteLine("  No borrowed books");
            }
        }
    }
}
