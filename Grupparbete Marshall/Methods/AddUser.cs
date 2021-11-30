using Grupparbete_Marshall.Classes;
using System;

namespace Grupparbete_Marshall.Methods
{
    internal class AddUser
    {
        public static void AddUsers() //metod för att lägga t anv
        {
            int age = 0; // start V är satt till 0
            int postNumber = 0;

            Console.Write("Enter your name: ");
            string name = Console.ReadLine();

            Console.Write("Enter your age: ");

            try
            {
                age = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input, try again ..");
            }

            Console.Write("Enter your Street Address: ");
            string streetAddress = Console.ReadLine();

            Console.Write("Enter your Postcode: ");
            try
            {
                postNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again..");
            }

            User user = new User(name, age, streetAddress, postNumber);
            LoginUser.currentUser = user; //metod den inloggade anv är currentuser är nu variablen user

            Console.WriteLine("You got ID: {0}", user.ID); // ditt anv id tilldelas
            Console.WriteLine("Remember it, you will use it to log in... ");

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }
    }
}