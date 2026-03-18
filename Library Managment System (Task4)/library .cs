using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Library_Managment_System__Task4_
{
    public class library
    {
        private Book[] BooksArray;
        private Member[] MembersArray;
        private Transaction[] TransactionsArray;

        public static int TotalBorrowedBooks { get; set; }

        private int BookCount;
        private int MemberCount;
        private int TransactionCount;
        public library(int maxBooks, int maxMembers, int maxTransactions)
        {
            BooksArray = new Book[maxBooks];
            MembersArray = new Member[maxMembers];
            TransactionsArray = new Transaction[maxTransactions];
            BookCount = 0;
            MemberCount = 0;
            TransactionCount = 0;
        }


        public void AddBook(Book book)
        {
            if (book == null)
            {
                Console.WriteLine("Book cannot be null.");
                return;
            }

            if (BookCount >= BooksArray.Length)
            {
                Console.WriteLine("Library is full. Cannot add more books.");
                return;
            }

            for (int i = 0; i < BookCount; i++)
            {
                if (BooksArray[i].Id == book.Id)
                {
                    Console.WriteLine($"Book : ({book.Id}) already exists!");
                    return;
                }
            }

            BooksArray[BookCount] = book;
            BookCount++;
        }

        public void AddMember(Member member)
        {
            if (member == null)
            {
                Console.WriteLine("Member cannot be null.");
                return;
            }

            if (MemberCount >= MembersArray.Length)
            {
                Console.WriteLine("Library is full. Cannot add more members.");
                return;
            }

            for (int i = 0; i < MemberCount; i++)
            {
                if (MembersArray[i] != null && MembersArray[i].Id == member.Id)
                {
                    Console.WriteLine($"Member : ({member.Id}) already exists!");
                    return;
                }
            }

            MembersArray[MemberCount] = member;
            MemberCount++;
        }

        public void BorrowBook(int memberId, int bookId)
        {
            // Find member
            Member member = FindMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine($"Member with ID {memberId} not found!");
                return;
            }

            // Find book
            Book book = FindBookById(bookId);
            if (book == null)
            {
                Console.WriteLine($"Book with ID {bookId} not found!");
                return;
            }

            // Try to borrow
            int previousBorrowIndex = member.BorrowIndex;
            member.BorrowBook(book);

            // If borrow was successful, add transaction
            if (member.BorrowIndex > previousBorrowIndex)
            {
                if (TransactionCount < TransactionsArray.Length)
                {
                    TransactionsArray[TransactionCount] = new Transaction
                    {
                        Id = TransactionCount + 1,
                        BookTitle = book.Title,
                        MemberName = member.Name,
                        Date = DateTime.Now,
                        Type = TransactionType.Borrow
                    };
                    TransactionCount++;
                }

                TotalBorrowedBooks++;
            }
        }

        public void ReturnBook(int memberId, int bookId, int daysLate)
        {
            // Find member
            Member member = FindMemberById(memberId);
            if (member == null)
            {
                Console.WriteLine($"Member with ID {memberId} not found!");
                return;
            }

            // Find book
            Book book = FindBookById(bookId);
            if (book == null)
            {
                Console.WriteLine($"Book with ID {bookId} not found!");
                return;
            }

            // Try to return
            int previousBorrowIndex = member.BorrowIndex;
            member.ReturnBook(book);

            // If return was successful
            if (member.BorrowIndex < previousBorrowIndex)
            {
                // Add transaction
                if (TransactionCount < TransactionsArray.Length)
                {
                    TransactionsArray[TransactionCount] = new Transaction() {
                        Id = TransactionCount + 1,
                        BookTitle = book.Title,
                        MemberName = member.Name,
                        Date = DateTime.Now,
                        Type = TransactionType.Return
                    };
                    TransactionCount++;
                }

                TotalBorrowedBooks--;

                // Calculate fine if member implements IFineCalculator
                if (member is IFineCalculator fineCalculator)
                {
                    double fine = fineCalculator.CalculateFine(daysLate);
                    if (fine > 0)
                    {
                        Console.WriteLine($"Late Fee: ${fine:F2}");
                    }
                    else
                    {
                        Console.WriteLine("Returned on time. No fine.");
                    }
                }
            }
        }

        public void PrintTransactions()
        {
            Console.WriteLine("\n===== Transactions History =====");

            if (TransactionCount == 0)
            {
                Console.WriteLine("No transactions found.");
                return;
            }

            for (int i = 0; i < TransactionCount; i++)
            {
                Transaction t = TransactionsArray[i];
                string typeSymbol = t.Type == TransactionType.Borrow ? "->" : "<-";
                Console.WriteLine($"[{t.Id}] {typeSymbol} {t.BookTitle} | {t.MemberName} | {t.Date:yyyy-MM-dd HH:mm}");
            }

            // Statistics
            int borrowCount = 0;
            int returnCount = 0;
            for (int i = 0; i < TransactionCount; i++)
            {
                if (TransactionsArray[i].Type == TransactionType.Borrow)
                    borrowCount++;
                else
                    returnCount++;
            }

            Console.WriteLine($"\nTotal Transactions: {TransactionCount}");
            Console.WriteLine($"Borrows: {borrowCount} | Returns: {returnCount}");
        }

        // Helper method to find member by ID
        private Member FindMemberById(int memberId)
        {
            for (int i = 0; i < MemberCount; i++)
            {
                if (MembersArray[i].Id == memberId)
                    return MembersArray[i];
            }
            return null;
        }

        // Helper method to find book by ID
        private Book FindBookById(int bookId)
        {
            for (int i = 0; i < BookCount; i++)
            {
                if (BooksArray[i].Id == bookId)
                    return BooksArray[i];
            }
            return null;
        }
    }
}