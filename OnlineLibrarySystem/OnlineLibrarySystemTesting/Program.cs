using System;
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

            var allUsers = u.GetAll();
            printList(allUsers);

            u.Add(new Customer("mimi@email.com", "123"));
            printList(u.GetAll());

            u.RemoveByID(1);
            printList(u.GetAll());

            var c = u.FindByEmail("mimi@email.com");
            Console.WriteLine(c.UserId);

            var customerList = u.FindByCategory(UserType.Customer);
            printList(customerList);

            // Test Login 
            var login = new LoginService();
            Console.WriteLine( "Sign in ok? {0}",login.LoginUser("mimi@email.com", "123"));

            // Test Register
            var register = new RegisterService();
            register.RegisterUser(new Customer("roger@email.com", "123"));

            var newRegUser = u.FindByEmail("roger@email.com");
            Console.WriteLine(newRegUser.Email);

            printList(u.GetAll());

            // Testing Resource Repository

            ResourceRepository rpos = new ResourceRepository();
            printList(rpos.GetAll());

            var audioList = rpos.FindByCategory(ResourceType.Audio);
            printList(audioList);





            Console.ReadLine();
        }

        public static void printList(IEnumerable<IResource> list)
        {
            foreach (var i in list)
                Console.WriteLine(i.Title);

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
