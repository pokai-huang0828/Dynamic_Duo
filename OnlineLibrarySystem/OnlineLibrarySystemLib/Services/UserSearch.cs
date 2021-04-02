using OnlineLibrarySystemLib.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Services
{
    public class UserSearch: IBasicSearch<IUser, UserType>
    {
        private UserRepository userRepository;

        public UserSearch()
        {
            userRepository = new UserRepository();
        }
        
        public IUser FindByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }

        public IEnumerable<IUser> FindByCategory(UserType userType)
        {
            return userRepository.GetUsersByCategory(userType);
        }

        public IEnumerable<IUser> FindByName(string name)
        {
            return UserData.UserList
                .Where(u => u.FirstName == name || u.LastName == name).ToList();
        }

        public IEnumerable<IUser> SearchRespository(
            string keyword, string category, string searchType)
        {
            var results = new List<IUser>();

            switch (searchType)
            {
                case "name":
                    results = FindByName(keyword).ToList();
                    break;

                case "userId":
                    int userID;
                    if (!Int32.TryParse(keyword, out userID))
                        break;

                    var result = userRepository.GetByID(userID);
                    if (result != null)
                        results.Add(result);
                    break;

                default:
                    results = userRepository.GetAll().ToList();
                    break;
            }

            // Filter users by category
            switch (category)
            {
                case "customer":
                    results = results.Where(u => u is Customer).ToList();
                    break;

                case "manager":
                    results = results.Where(m => m is Manager).ToList();
                    break;
            }

            return results;
        }

    }
}
