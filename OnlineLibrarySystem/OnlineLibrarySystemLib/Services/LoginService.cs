using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Services
{
    public class LoginService
    {
        private readonly UserSearch userSearch;

        public LoginService()
        {
            userSearch = new UserSearch();
        }

        public bool LoginUser(string email, string password)
        {
            try
            {
                var user = userSearch.FindByEmail(email);

                if (user != null &&
                    user.Email == email &&
                    user.Password == password)
                    return true;

            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }


    }
}
