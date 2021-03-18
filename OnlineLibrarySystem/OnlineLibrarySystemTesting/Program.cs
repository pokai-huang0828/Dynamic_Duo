using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineLibrarySystemLib;

namespace OnlineLibrarySystemTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            var userRepository = UserRepository.Instance;

            /* GetAll() */
            var users = userRepository.GetAll();

/*            foreach(var u in users)
            {
                Console.WriteLine($"ID:{u.UserId} Name:{u.FirstName}");
            }*/

            /* FindByName */
            users = userRepository.FindByName("Kelly");
/*            foreach (var u in users)
            {
                Console.WriteLine($"ID:{u.UserId} Name:{u.FirstName}");
            }
*/

            /* GetByID */
            var user = userRepository.GetByID(0);
            Console.WriteLine($"ID:{user.UserId} Name:{user.FirstName}");



            Console.ReadLine();

        }
    }
}
