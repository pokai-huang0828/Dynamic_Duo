﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrarySystemLib;
using OnlineLibrarySystemLib.Services;

namespace OnlineLibrarySystemTesting
{
    public class Program
    {
        static void Main(string[] args)
        {

            UserRepository u = new UserRepository();
            UserSearch us = new UserSearch();

            var allUsers = u.GetAll();
            printList(allUsers);

            u.Add(new Customer("mimi@email.com", "123"));
            printList(u.GetAll());

            u.RemoveByID(1);
            printList(u.GetAll());

            var c = us.FindByEmail("mimi@email.com");
            Console.WriteLine(c.UserId);

            var customerList = us.FindByCategory(UserType.Customer);
            printList(customerList);

            // Testing Update User
            var olduser = u.GetByID(2);
            Console.WriteLine($"oldUser firstName: {olduser.FirstName}");
            olduser.FirstName = "McLovin";
            u.Update(olduser);
            var newuser = u.GetByID(2);
            Console.WriteLine($"newUser firstName: {newuser.FirstName}");
           
            // Test Login 
            var login = new LoginService();
            Console.WriteLine( "Sign in ok? {0}",login.LoginUser("mimi@email.com", "123"));

            // Test Register
            var register = new RegisterService();
            register.RegisterUser(new Customer("roger@email.com", "123"));

            var newRegUser = us.FindByEmail("roger@email.com");
            Console.WriteLine(newRegUser.Email);

            printList(u.GetAll());

            // Testing Resource Repository

            ResourceRepository rpos = new ResourceRepository();
            ResourceSearch rsearch = new ResourceSearch();
            printList(rpos.GetAll());

            var audioList = rsearch.FindByCategory(ResourceType.Audio);
            printList(audioList);


            Console.ReadLine();
        }

        public static void printList(IEnumerable<IResource> list)
        {
            foreach (var i in list)
                Console.WriteLine(i.ResourceID+ " "+ i.Title);

            Console.WriteLine("");
        }

        public static void printList(IEnumerable<IUser> list)
        {
            foreach (var i in list)
                Console.WriteLine(i.FirstName);

            Console.WriteLine("");
        }


    }
}
