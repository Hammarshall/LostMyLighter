﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Grupparbete_Marshall.Classes;

namespace Grupparbete_Marshall.Methods
{
    class LoginUser
    {
        public static User currentUser = new User();
        public static void UserLogin()
        {

            Console.WriteLine("Please enter your user ID: ");
            int id = int.Parse(Console.ReadLine());


            currentUser = User.GetUserById(id);

            //Menus.LoginMenu.StartLoginMenu(); Mintamir

        }



    }
}
