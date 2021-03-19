using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Services
{
    public class RegisterService
    {
        private readonly UserRepository userRepository;

        public RegisterService()
        {
            userRepository = new UserRepository();
        }

        public int? RegisterUser(IUser user)
        {
            try
            {
                return userRepository.Add(user);

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return null;
        }
    }
}
