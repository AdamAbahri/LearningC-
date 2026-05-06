using System;
using System.Collections.Generic;
using System.Linq;

namespace EF2
{
    internal class Program
    {
        public void menu(ApplicationDbContext context)
        {
            while (true)
            {
                const string menuText = "Menu:\n" +
                    "1. Add User\n" +
                    "2. View Users\n" +
                    "3. Update User\n" +
                    "4. Delete User\n" +
                    "5. LINQ\n" +
                    "6. Exit\n" +
                    "Enter your choice: ";

                Console.Write(menuText);

                if (!int.TryParse(Console.ReadLine(), out int x))
                {
                    Console.WriteLine("Invalid input.\n");
                    continue;
                }

                switch (x)
                {
                    case 1:
                        Console.Write("Enter user name: ");
                        string name = Console.ReadLine();

                        Console.Write("Enter user price: ");
                        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
                        {
                            Console.WriteLine("Invalid price.\n");
                            break;
                        }

                        addUsers(context, name, price);
                        break;

                    case 2:
                        viewUsers(context);
                        break;

                    case 3:
                        updateUser(context);
                        break;

                    case 4:
                        deleteUser(context);
                        break;

                    case 5:
                        linq(context);
                        break;

                    case 6:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            }
        }

        public void addUsers(ApplicationDbContext context, string name, decimal price)
        {
            var user = new User
            {
                Name = name,
                Price = price
            };

            context.Users.Add(user);
            context.SaveChanges();

            Console.WriteLine("User added successfully.\n");
        }

        public void viewUsers(ApplicationDbContext context)
        {
            var users = context.Users.ToList();

            printUsers(users);
        }

        public void updateUser(ApplicationDbContext context)
        {
            Console.Write("Enter user Id to update: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.\n");
                return;
            }

            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                Console.WriteLine("User not found.\n");
                return;
            }

            Console.Write("Enter new name: ");
            user.Name = Console.ReadLine();

            Console.Write("Enter new price: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price))
            {
                Console.WriteLine("Invalid price.\n");
                return;
            }

            user.Price = price;

            context.SaveChanges();

            Console.WriteLine("User updated successfully.\n");
        }

        public void deleteUser(ApplicationDbContext context)
        {
            Console.Write("Enter user Id to delete: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Invalid Id.\n");
                return;
            }

            var user = context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                Console.WriteLine("User not found.\n");
                return;
            }

            context.Users.Remove(user);
            context.SaveChanges();

            Console.WriteLine("User deleted successfully.\n");
        }

        public void linq(ApplicationDbContext context)
        {
            while (true)
            {
                const string menuText = "\nLINQ Menu:\n" +
                    "1. Price > 100\n" +
                    "2. Price Between 50 - 100\n" +
                    "3. Order By Desc Price\n" +
                    "4. Lowest 3 Prices\n" +
                    "5. Top Price\n" +
                    "6. Exit\n" +
                    "Enter your choice: ";

                Console.Write(menuText);

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid choice.\n");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        printUsers(context.Users.Where(u => u.Price > 100).ToList());
                        break;

                    case 2:
                        printUsers(context.Users.Where(u => u.Price >= 50 && u.Price <= 100).ToList());
                        break;

                    case 3:
                        printUsers(context.Users.OrderByDescending(u => u.Price).ToList());
                        break;

                    case 4:
                        printUsers(context.Users.OrderBy(u => u.Price).Take(3).ToList());
                        break;

                    case 5:
                        var user = context.Users.OrderByDescending(u => u.Price).FirstOrDefault();
                        if (user != null)
                            Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Price: {user.Price}\n");
                        else
                            Console.WriteLine("No data found.\n");
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Invalid choice.\n");
                        break;
                }
            }
        }

        
        public void printUsers(List<User> users)
        {
            if (!users.Any())
            {
                Console.WriteLine("No users found.\n");
                return;
            }

            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Price: {user.Price}");
            }

            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            using (var context = new ApplicationDbContext())
            {
                Program p = new Program();
                p.menu(context);
            }
        }
    }
}