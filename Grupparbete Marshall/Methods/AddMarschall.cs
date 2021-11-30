using Grupparbete_Marshall.Classes;
using System;

namespace Grupparbete_Marshall.Methods
{
    internal class AddMarschall
    {
        public static void AddMarschalls() //metod för att lägga t Marschaller
        {
            double burnTime = 0; // allt har start V 0
            int streetNumber = 0;
            int postalCode = 0;

            Console.Write("Enter the marschall's brand: ");
            string brand = Console.ReadLine();

            Console.Write("Enter the street address where the marschall is located: ");
            string streetName = Console.ReadLine();

            Console.Write("Enter the street number where the marschall is located: ");
            try
            {
                streetNumber = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();

                Console.WriteLine("Invalid input, try again..");
            }

            Console.Write("Enter the postal code where the marschall is located: ");
            try
            {
                postalCode = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again..");
            }

            Console.Write("Enter the marschall's burning time in minutes: ");
            try
            {
                burnTime = double.Parse(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Invalid input, try again..");
            }

            Console.WriteLine("The marschall was registered at {0}", DateTime.Now);

            Console.WriteLine("The marschall is expected to burn out at {0} ", DateTime.Now.AddMinutes(burnTime)); // tiden Marschallen reggades, addera min som den ska brinna, skicka med burntime

            Marschall marschall = new Marschall(brand, burnTime, LoginUser.currentUser.ID, streetName, streetNumber, postalCode);
            User.AddFoundMarshall(LoginUser.currentUser); //addera marshallen till anv

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }
    }
}