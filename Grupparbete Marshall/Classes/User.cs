using Grupparbete_Marshall.Methods;
using System;
using System.Collections.Generic;

namespace Grupparbete_Marshall.Classes
{
    internal class User
    {
        public static List<User> userList = new List<User>(); // user listan

        public static void InitializeUserList() //user list med anv
        {
            new User("Anders Andersson", 30, "Exempeladress 1", 40010, 0, 0, 0); // Förnamn, efternamn, adress
            new User("Anders Johansson", 30, "Exempeladress 2", 40010, 0, 0, 0);
            new User("Anders Göransson", 30, "Exempeladress 3", 40010, 0, 0, 5);
            new User("Anders Nilsson", 30, "Exempeladress 4", 40010, 0, 0, 0);
            new User("Anders Olsson", 30, "Exempeladress 5", 40010, 0, 0, 0);
        }

        //fields
        private int _id;
        private string _name;
        private int _age;
        private string _streetAddress;
        private int _postNumber;
        private int _numberOfSearch = 0;
        private int _foundMarschall = 0;
        private int _lostLighters = 0;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        public User() // tom konstruktor
        {
        }

        public User(string n, int a, string s, int p, int ns, int f, int l) //konstruktor
        {
            this._id = userList.Count + 1;
            this._name = n;
            this._age = a;
            this._streetAddress = s;
            this._postNumber = p;
            this._numberOfSearch = ns;
            this._foundMarschall = f;
            this._lostLighters = l;
            userList.Add(this); // metoden att lägga t anv t listan
        }

        public User(string n, int a, string s, int p)
        {
            this._id = userList.Count + 1;
            this._name = n;
            this._age = a;
            this._streetAddress = s;
            this._postNumber = p;
            userList.Add(this);
        }

        public static void PrintUser(User user) //metod skriv ut user
        {
            Console.WriteLine("ID:{0}", user._id);
            Console.WriteLine("Name:{0}", user._name);
            Console.WriteLine("Age:{0}", user._age);
            Console.WriteLine("Street Adress:{0}", user._streetAddress);
            Console.WriteLine("Post Number:{0}", user._postNumber);
            Console.WriteLine("Number Of Search:{0}", user._numberOfSearch);
            Console.WriteLine("Found Marchall:{0}", user._foundMarschall);
            Console.WriteLine("Lost Lighters:{0}", user._lostLighters);

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }

        public static string GetUserName(User user) //metod få ut anv via anv-namn
        {
            return user._name;
        }

        public static User GetUserById(int id) // få ut anv via anv-id
        {
            foreach (User u in userList) //för varje anv i user list
            {
                if (u._id == id) //om user id = id retunera U
                {
                    return u;
                }
            }

            Console.WriteLine("That was not a valid ID, try again.."); //om user id ej finns gör detta
            return null; // retur ett null värde
        }

        public static void AddSearch(User user) //metod addera antl sökningar
        {
            user = GetUserById(LoginUser.currentUser._id); // metod, user = dess unika id som de är inloggade med
            user._numberOfSearch++; // lägg till en sökning 
        }

        public static void AddFoundMarshall(User user) // metod addera antl funna Marschaller
        {
            user = GetUserById(LoginUser.currentUser._id);
            user._foundMarschall++; // lägg till en "pinne"
        }

        public static void AddLostLighter(User user) //Metod addera antl bortappade tändare
        {
            user = GetUserById(LoginUser.currentUser._id);
            user._lostLighters++;

            Console.WriteLine("Lost lighter has been recorded"); // skrivs ut när man lagt till att man har tappat en tändare

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }

        public static void EditUserMethod(User user) // ändra i user
        {
            int userInput = 0;

            do
            {
                Console.WriteLine("Choose what you want to change: ");
                Console.WriteLine("1. Change name");
                Console.WriteLine("2. Change age");
                Console.WriteLine("3. Change address");

                try
                {
                    userInput = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("You must select a number from the menu. Press any key to try again: ");
                }
            } while (userInput == 0);

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Change name: ");
                    LoginUser.currentUser._name = Console.ReadLine();
                    break;

                case 2:
                    Console.WriteLine("Change age: ");
                    LoginUser.currentUser._age = Convert.ToInt32(Console.ReadLine());
                    break;

                case 3:
                    Console.WriteLine("Change address: ");
                    LoginUser.currentUser._streetAddress = Console.ReadLine();
                    break;
            }

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }

        public static void FoundMarschallScore() // Metod, score för antl hittade marschaller

        {
            User TopScores = new User();
            foreach (var users in userList)
            {
                if (users == null)
                {
                    break;
                }
                if (users._foundMarschall > TopScores._foundMarschall)
                {
                    TopScores = users;
                }
            }
            Console.WriteLine("The user who has found the most marschalls is... ");
            Console.WriteLine();
            PrintUser(TopScores);

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }

        public static void LighterHighScore()
        {
            User TopScores = new User();
            foreach (var users in userList)
            {
                if (users == null)
                {
                    break;
                }
                if (users._lostLighters > TopScores._lostLighters)
                {
                    TopScores = users;
                }
            }

            Console.WriteLine("The user who has lost the most lighters is... ");
            Console.WriteLine();
            PrintUser(TopScores);

            Console.WriteLine("Press any key to clear console and return to main menu...");
            Console.ReadKey();
            Console.Clear();
            Menus.MenuAtLogin.LoginMenu();
        }
    }
}