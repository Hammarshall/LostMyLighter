using Grupparbete_Marshall.Classes;
using System;
using System.Linq;

namespace Grupparbete_Marshall.Methods
{
    internal class FilterActiveMarschall
    {
        public static void FilterMarschall() //metod filtrera aktiva Marschaller på post nr
        {
            int filterPostCode = 0; //start V är satt till 0

            Console.WriteLine("Enter postCode: ");
            filterPostCode = int.Parse(Console.ReadLine());

            var matchingMarschalls = Marschall.marschallList.Where(marschall => marschall.PostalCode == filterPostCode); // Där postkoden matchar i den postkoden i MList,

            Console.Clear();

            foreach (Marschall marschall in matchingMarschalls) // för varje Marschall i Matching marschalls
            {
                Marschall.PrintMarschall(marschall); // metod skriv ut dem
            }
            User.AddSearch(LoginUser.currentUser); // Metod addera sökingen på anv
            Console.WriteLine("\n Press any key to return to Main menu");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }
    }
}