using Grupparbete_Marshall.Classes;
using Grupparbete_Marshall.Methods;
using System;

namespace Grupparbete_Marshall.Menus
{
    internal class MenuAtLogin
    {
        public static void LoginMenu()
        {
            int option = 0; //start V på anv input = 0

            do
            {
                bool isInvalidInput = false;
                do
                {
                    Console.WriteLine(@"Main menu
0. Add new marschall
1. List all registered marschalls
2. List all active marschalls
3. Filter marschalls by postalcode
4. List all your marschalls
5. Show profile
6. Change user profile

7. Register a lost lighter
8. Highscore amount of lost lighters
9. Highscore amount of found marschalls
10. Log out");

                    try
                    {
                        option = int.Parse(Console.ReadLine());
                        isInvalidInput = false;
                        break;
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input, try again...");
                        isInvalidInput = true;
                    }
                } while (isInvalidInput);

                switch (option)
                {
                    case 0:
                        AddMarschall.AddMarschalls(); // kallar på metoden add Marschall och delen Add amrschalls
                        break;

                    case 1:
                        Marschall.PrintAllMarschalls(); //klassen marschall, metoden print all marschalls
                        break;

                    case 2:
                        Marschall.PrintActiveMarschall(); // skriv ut alla aktiva marschaller
                        break;

                    case 3:
                        FilterActiveMarschall.FilterMarschall(); //filtrera så man bara ser aktiva marschaller
                        break;

                    case 4:
                        Marschall.PrintUserMarschall(LoginUser.currentUser); //skriv ut alla marschaller anv har reggat
                        break;
                    case 5:
                        User.PrintUser(LoginUser.currentUser); //skriv ut den anv profil som är inloggad
                        break;

                    case 6:
                        User.EditUserMethod(LoginUser.currentUser); //ropar på metoden ändra i anv
                        break;

                    case 7:
                        User.AddLostLighter(LoginUser.currentUser); //metoden för att lägga t en borttappad tändare
                        break;

                    case 8:
                        User.LighterHighScore(); // se highscore för flest borttappade tändare
                        break;

                    case 9:
                        User.FoundMarschallScore(); // se highscore för flest upphittade marschaller
                        break;

                    case 10:
                        Startmenu.RunStartMenu();
                        break;

                    default:
                        Console.WriteLine("Invalid input, try again!"); //om inget mmatchar casen
                        break;
                }
            } while (option != 0); // gör detta sålänge options värde ej är 0
        }
    }
}