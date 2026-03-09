namespace Library_System
{
    public class Program
    {
        static void MainMenu(Library publicLibrary, Library universityLibrary)
        {
            while (true)
            {
                Console.WriteLine("\n================= Main Menu =================");
                Console.WriteLine("Select Library Type : ");
                Console.WriteLine("1. Public Library");
                Console.WriteLine("2. University Library");
                Console.WriteLine("3. Manager Mode");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("\n--- Public Library Selected ---");
                    Console.WriteLine($"Name: {publicLibrary.Name}");
                    Console.WriteLine($"Address: {publicLibrary.Address}");
                    Console.WriteLine($"Current Mode: {publicLibrary.CurrentMode}");

         
                    Console.WriteLine("\nDo you want to change the mode before viewing books?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No, continue to view books");
                    Console.Write("Your choice: ");

                    int modeChoice = int.Parse(Console.ReadLine());

                    if (modeChoice == 1)
                    {
                        ChangeLibraryMode(publicLibrary);
                    }

                    
                    PLibrary(publicLibrary);
                }
                else if (choice == 2)
                {
                    Console.WriteLine("\n--- University Library Selected ---");
                    Console.WriteLine($"Name: {universityLibrary.Name}");
                    Console.WriteLine($"Address: {universityLibrary.Address}");
                    Console.WriteLine($"Current Mode: {universityLibrary.CurrentMode}");

                    
                    Console.WriteLine("\nDo you want to change the mode before viewing books?");
                    Console.WriteLine("1. Yes");
                    Console.WriteLine("2. No, continue to view books");
                    Console.Write("Your choice: ");

                    int modeChoice = int.Parse(Console.ReadLine());

                    if (modeChoice == 1)
                    {
                        ChangeLibraryMode(universityLibrary);
                    }

                   
                    ULibrary(universityLibrary);
                }
                else if (choice == 3)
                {
                    ManagerMode(publicLibrary, universityLibrary);
                }
                else if (choice == 4)
                {
                    Console.WriteLine("Exiting system. Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void ManagerMode(Library publicLibrary, Library universityLibrary)
        {
            while (true)
            {
                Console.WriteLine("\n================= Manager Mode =================");
                Console.WriteLine("Select Library to Manage:");
                Console.WriteLine("1. Public Library");
                Console.WriteLine("2. University Library");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Your choice: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    ManageLibrary(publicLibrary, "Public");
                }
                else if (choice == 2)
                {
                    ManageLibrary(universityLibrary, "University");
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void ManageLibrary(Library library, string libraryType)
        {
            while (true)
            {
                Console.WriteLine($"\n--- Managing {libraryType} Library: {library.Name} ---");
                Console.WriteLine("1. Edit Library Information");
                Console.WriteLine("2. Manage Book Copies");
                Console.WriteLine("3. View All Books");
                Console.WriteLine("4. Back to Library Selection");
                Console.Write("Your choice: ");

                int choice = int.Parse(Console.ReadLine());

                if (choice == 1)
                {
                    EditLibraryInfo(library);
                }
                else if (choice == 2)
                {
                    ManageCopies(library);
                }
                else if (choice == 3)
                {
                    ViewAllBooks(library);
                }
                else if (choice == 4)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void EditLibraryInfo(Library library)
        {
            Console.WriteLine("\n--- Edit Library Information ---");
            Console.WriteLine($"Current Name: {library.Name}");
            Console.Write("Enter New Name (or press Enter to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
            {
                library.Name = newName;
            }

            Console.WriteLine($"\nCurrent Address: {library.Address}");
            Console.Write("Enter New Address (or press Enter to keep current): ");
            string newAddress = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newAddress))
            {
                library.Address = newAddress;
            }

            Console.WriteLine($"\nCurrent Mode: {library.CurrentMode}");
            Console.WriteLine("Change Mode?");
            Console.WriteLine("1. Yes");
            Console.WriteLine("2. No");
            Console.Write("Your choice: ");

            int modeChoice = int.Parse(Console.ReadLine());
            if (modeChoice == 1)
            {
                ChangeLibraryMode(library);
            }

            Console.WriteLine("\nLibrary information updated successfully!");
        }

        static void ManageCopies(Library library)
        {
            if (library.Books == null || library.Books.Length == 0)
            {
                Console.WriteLine("No books available in this library.");
                return;
            }

            Console.WriteLine("\n--- Manage Book Copies ---");
            for (int i = 0; i < library.Books.Length; i++)
            {
                if (library.Books[i] != null)
                {
                    Console.WriteLine($"{i + 1}. {library.Books[i].Title} by {library.Books[i].Author} - Current Copies: {library.Books[i].Copies}");
                }
            }

            Console.Write("\nSelect book number to manage copies: ");
            int bookIndex = int.Parse(Console.ReadLine()) - 1;

            if (bookIndex >= 0 && bookIndex < library.Books.Length && library.Books[bookIndex] != null)
            {
                Book selectedBook = library.Books[bookIndex];
                Console.WriteLine($"\nManaging: {selectedBook.Title}");
                Console.WriteLine($"Current Copies: {selectedBook.Copies}");
                Console.WriteLine("1. Add Copies");
                Console.WriteLine("2. Remove Copies");
                Console.WriteLine("3. Cancel");
                Console.Write("Your choice: ");

                int action = int.Parse(Console.ReadLine());

                if (action == 1)
                {
                    Console.Write("Enter number of copies to add: ");
                    int addCopies = int.Parse(Console.ReadLine());
                    selectedBook.Copies += addCopies;
                    Console.WriteLine($"Added {addCopies} copies. New total: {selectedBook.Copies}");
                }
                else if (action == 2)
                {
                    Console.Write("Enter number of copies to remove: ");
                    int removeCopies = int.Parse(Console.ReadLine());
                    if (removeCopies < selectedBook.Copies)
                    {
                        selectedBook.Copies -= removeCopies;
                        Console.WriteLine($"Removed {removeCopies} copies. New total: {selectedBook.Copies}");
                    }
                    else
                    {
                        Console.WriteLine("Cannot remove all copies. Each book must have at least one copy.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid book selection.");
            }
        }

        static void ViewAllBooks(Library library)
        {
            Console.WriteLine($"\n--- All Books in {library.Name} ---");
            if (library.Books != null)
            {
                foreach (Book book in library.Books)
                {
                    if (book != null)
                    {
                        Console.WriteLine($"\nTitle: {book.Title}");
                        Console.WriteLine($"Author: {book.Author}");
                        Console.WriteLine($"ISBN: {book.ISBN}");
                        Console.WriteLine($"Copies: {book.Copies}");
                        if (!string.IsNullOrEmpty(book.Department))
                        {
                            Console.WriteLine($"Department: {book.Department}");
                            Console.WriteLine($"Course: {book.Course}");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No books in this library.");
            }
        }

        static void ChangeLibraryMode(Library a)
        {
            Console.WriteLine("\n--- Change Library Mode ---");
            Console.WriteLine("1. Change to OPEN");
            Console.WriteLine("2. Change to CLOSED");
            Console.WriteLine("3. Change to MAINTENANCE");
            Console.Write("Your choice: ");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                a.CurrentMode = Modes.Opened;
                Console.WriteLine("Mode changed to OPEN");
            }
            else if (choice == 2)
            {
                a.CurrentMode = Modes.Closed;
                Console.WriteLine("Mode changed to CLOSED");
            }
            else if (choice == 3)
            {
                a.CurrentMode = Modes.Maintenance;
                Console.WriteLine("Mode changed to MAINTENANCE");
            }
        }

        static void PLibrary(Library a)
        {
            switch (a.CurrentMode)
            {
                case Modes.Opened:
                    Console.WriteLine("\nLibrary is Opened");
                    if (a.Books != null)
                    {
                        foreach (Book book in a.Books)
                        {
                            if (book != null)
                            {
                                if (book.Copies == 0)
                                {
                                    Console.WriteLine($"Book: {book.Title} is out of stock");
                                }
                                else
                                {
                                    Console.WriteLine($"Book: {book.Title} by {book.Author} and ISBN is {book.ISBN} is available with {book.Copies} copies");
                                }
                            }
                        }
                    }
                    break;

                case Modes.Closed:
                    Console.WriteLine("\nWARNING: Library is CLOSED. Cannot view books.");
                    break;

                case Modes.Maintenance:
                    Console.WriteLine("\nLibrary is under MAINTENANCE. Cannot view books.");
                    break;
            }
        }

        static void ULibrary(Library a)
        {
            switch (a.CurrentMode)
            {
                case Modes.Opened:
                    Console.WriteLine("\nLibrary is Opened");
                    Console.Write("Enter Department Name: ");
                    string department = Console.ReadLine();

                    Console.WriteLine($"\nAvailable Courses in {department} Department:");
                    List<string> courses = new List<string>();

                    if (a.Books != null)
                    {
                        foreach (Book book in a.Books)
                        {
                            if (book != null && book.Department == department)
                            {
                                if (!courses.Contains(book.Course))
                                {
                                    courses.Add(book.Course);
                                    Console.WriteLine($"{courses.Count}. {book.Course}");
                                }
                            }
                        }
                    }

                    if (courses.Count == 0)
                    {
                        Console.WriteLine($"No courses found in {department} department");
                        break;
                    }

                    Console.Write("\nEnter The Course Name: ");
                    string selectedCourse = Console.ReadLine();

                    Console.WriteLine($"\nBooks for Course {selectedCourse}:");
                    bool found = false;

                    foreach (Book book in a.Books)
                    {
                        if (book != null && book.Department == department && book.Course == selectedCourse)
                        {
                            found = true;
                            if (book.Copies == 0)
                            {
                                Console.WriteLine($"{book.Title} is out of stock");
                            }
                            else
                            {
                                Console.WriteLine($"{book.Title} by {book.Author}");
                                Console.WriteLine($"   ISBN: {book.ISBN}");
                                Console.WriteLine($"   Available Copies: {book.Copies}\n");
                            }
                        }
                    }

                    if (!found)
                    {
                        Console.WriteLine($"No books found for course {selectedCourse}");
                    }
                    break;

                case Modes.Closed:
                    Console.WriteLine("\nWARNING: Library is CLOSED. Cannot view books.");
                    break;

                case Modes.Maintenance:
                    Console.WriteLine("\nLibrary is under MAINTENANCE. Cannot view books.");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Book[] books = new Book[]
            {
                new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", ISBN = "978-0-7432-7356-5", Copies = 5 },
                new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", ISBN = "978-0-06-112008-4", Copies = 0 },
                new Book { Title = "1984", Author = "George Orwell", ISBN = "978-0-452-28423-4", Copies = 7 },
                new Book { Title = "Pride and Prejudice", Author = "Jane Austen", ISBN = "978-0-14-143951-8", Copies = 2 },
                new Book { Title = "The Catcher in the Rye", Author = "J.D. Salinger", ISBN = "978-0-316-76948-0", Copies = 4 },
                new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", ISBN = "978-0-547-92822-7", Copies = 6 },
                new Book { Title = "Moby Dick", Author = "Herman Melville", ISBN = "978-0-14-243724-7", Copies = 0},
                new Book { Title = "War and Peace", Author = "Leo Tolstoy", ISBN = "978-0-19-923276-5", Copies = 2 },
                new Book { Title = "The Odyssey", Author = "Homer", ISBN = "978-0-14-026886-7", Copies = 3 },
                new Book { Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", ISBN = "978-0-14-305814-4", Copies = 4 }
            };

            Book[] universityBooks = new Book[]
            {
                new Book { Title = "Introduction to Algorithms", Author = "Thomas H. Cormen", ISBN = "978-0-262-03384-8", Copies = 5, Department = "Computer Science", Course = "CS201" },
                new Book { Title = "Calculus: Early Transcendentals", Author = "James Stewart", ISBN = "978-0-495-01166-8", Copies = 8, Department = "Mathematics", Course = "MATH101" },
                new Book { Title = "University Physics", Author = "Hugh D. Young", ISBN = "978-0-321-69686-1", Copies = 4, Department = "Physics", Course = "PHY101" },
                new Book { Title = "Organic Chemistry", Author = "Paula Yurkanis Bruice", ISBN = "978-0-321-80322-1", Copies = 3, Department = "Chemistry", Course = "CHEM201" },
                new Book { Title = "Molecular Biology of the Cell", Author = "Bruce Alberts", ISBN = "978-0-8153-4464-3", Copies = 2, Department = "Biology", Course = "BIO301" },
                new Book { Title = "Engineering Mechanics", Author = "R.C. Hibbeler", ISBN = "978-0-13-391892-2", Copies = 6, Department = "Engineering", Course = "ENG101" },
                new Book { Title = "Principles of Economics", Author = "N. Gregory Mankiw", ISBN = "978-0-538-45305-9", Copies = 7, Department = "Economics", Course = "ECO101" },
                new Book { Title = "Introduction to Psychology", Author = "James W. Kalat", ISBN = "978-1-305-27892-7", Copies = 4, Department = "Psychology", Course = "PSY101" },
                new Book { Title = "Calculus 1", Author = "William J. Duiker", ISBN = "978-1-305-09001-7", Copies = 0, Department = "Mathematics", Course = "MATH101" },
                new Book { Title = "Calculus 2", Author = "Stephen Greenblatt", ISBN = "978-0-393-60312-5", Copies = 2, Department = "Mathematics", Course = "MATH102" }
            };

            Manager adam = new Manager()
            {
                Name = "Adam Abahri",
                Id = 123,
                Email = "Adam123@gmail.com"
            };

            Console.WriteLine("================= Welcome to Library System =================");

            Console.WriteLine("\n--- Initialize Public Library ---");
            Console.Write("Enter Public Library Name: ");
            string publicName = Console.ReadLine();
            Console.Write("Enter Public Library Address: ");
            string publicAddress = Console.ReadLine();
            Console.WriteLine("Enter Library Mode (1. Opened, 2. Closed, 3. Maintenance): ");
            int publicMode = int.Parse(Console.ReadLine());

            Library PublicLibrary = new Library
            {
                Name = publicName,
                Address = publicAddress,
                LibraryManager = adam,
                CurrentMode = (Modes)publicMode,
                Books = books
            };

            Console.WriteLine("\n--- Initialize University Library ---");
            Console.Write("Enter University Library Name: ");
            string uniName = Console.ReadLine();
            Console.Write("Enter University Library Address: ");
            string uniAddress = Console.ReadLine();
            Console.WriteLine("Enter Library Mode (1. Opened, 2. Closed, 3. Maintenance): ");
            int uniMode = int.Parse(Console.ReadLine());

            Library UniversityLibrary = new Library
            {
                Name = uniName,
                Address = uniAddress,
                LibraryManager = adam,
                CurrentMode = (Modes)uniMode,
                Books = universityBooks
            };

            MainMenu(PublicLibrary, UniversityLibrary);
        }
    }
}
