using System;
using System.Collections.Generic;
using System.Linq;

namespace Grupparbete_Marshall.Classes
{
    internal class Marschall //klassen för marschallerna
    {
        public static List<Marschall> marschallList = new List<Marschall>(); // listan där vi sparar alla marschaller

        //marschallens fields

        private int id;
        private string brand;
        private double burntime;
        private DateTime reg_stamp;
        private User reg_user; // anv som reggade
        private DateTime burnout;
        private string streetName = "unknown"; // i detta stadiet är adressen som defult satt till okänd
        private int streetNumber;
        // private string region;
        private int postalCode;

        public DateTime Burnout // när den kmr brinna ut
        {
            get { return burnout; } //retur tiden för burnout
            set { burnout = value; } // sätter värdet aka tiden för när den brinner ut
        }

        public int PostalCode //postkod
        {
            get { return postalCode; }
            set { postalCode = value; }
        }

        public User RegUser //anv som regga
        {
            get { return reg_user; }
            set { reg_user = value; }
        }

        public Marschall(string _brand, double bTime, int i, string sName, int sNumber, int pCode) //konstruktorn som skapar marshallerna
        {
            id = marschallList.Count + 1; // idt sätts baserat på antal M det finns i listan 1+
            brand = _brand;
            reg_stamp = DateTime.Now;
            reg_user = User.GetUserById(i);
            burntime = bTime;
            burnout = reg_stamp.AddMinutes(burntime);
            streetName = sName;
            streetNumber = sNumber;
            postalCode = pCode;
            marschallList.Add(this); //metod för att lägga till den i listan
        }

        public Marschall(string bn, int id, double bt, DateTime dt, int pc)
        {
            this.id = marschallList.Count + 1;
            this.brand = bn;
            this.burntime = bt;
            this.reg_stamp = dt;
            this.postalCode = pc;
            reg_user = User.GetUserById(id);
            burnout = reg_stamp.AddHours(burntime);
            marschallList.Add(this);
        }

        public static void InitializeMarschallList() //inisiera listan med marschaller
        {
            DateTime date1 = new DateTime(2021, 11, 16, 12, 0, 0, 0); //YY-MM-DD, HH-MI-SEK

            new Marschall("Solstickan", 60, 2, "Nergårdsvägen", 43, 43636);
            new Marschall("Solstickan", 60, 1, "Pilegårdsvägen", 1, 43635);
            new Marschall("Solstickan", 120, 4, "Tycho Brahes gata", 11, 41517);
            new Marschall("Sostickan", 2, 1, date1, 41517);
            new Marschall("Solstickan", 3, 1, date1, 43636);
        }

        public static void PrintAllMarschalls() //metod, skriva ut alla marschaller
        {
            foreach (Marschall m in marschallList) //för varje Marschall i MList skriv ut
            {
                PrintMarschall(m);
            }

            Console.WriteLine("Press any key to clear console and return to main menu..."); //när man sskrivit ut alla Marschaller
            Console.ReadKey();
            Console.Clear(); //rensa consollen
            Menus.MenuAtLogin.LoginMenu(); //metod tbx till log in meny
        }

        public static void PrintMarschall(Marschall marschall) //skriver ut alla Marschaller anv har reggat
        {
            Console.WriteLine("ID: {0}", marschall.id);
            Console.WriteLine("Brand: {0}", marschall.brand);
            Console.WriteLine("Street: {0} {1}", marschall.streetName, marschall.streetName == "unknown" ? "" : marschall.streetNumber);
            Console.WriteLine($"Postalcode: {marschall.postalCode/100} {marschall.postalCode%100}");
            Console.WriteLine("Registered by: {0}", User.GetUserName(marschall.reg_user));
            Console.WriteLine();
        }

        public static void PrintActiveMarschall() // skriv ut alla aktiva marschaller
        {
            var activeMarschall = marschallList.Where(marschall => marschall.Burnout > DateTime.Now); // i MList där Marschallens brinntid är större än tiden just nu, vilket visar på att den "är igång"
            foreach (Marschall m in activeMarschall) // För varje Marshchall i MList som uppfyller de kravet skriv ut
            {
                PrintMarschall(m);
            }

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu(); // gå tbx till log in meny och rensa consolen
        }

        public static void PrintUserMarschall(User user) //Klassen User
        {
            foreach (Marschall m in marschallList.Where(marschall => marschall.RegUser.Equals(user))) // Varje M i MList där en specifik user har reggat
            {
                PrintMarschall(m); //skriv ut 
            }

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }
    }
}