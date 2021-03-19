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
        public IUser FindByEmail(string email)
        {
            return UserData.UserList.Find(u => u.Email == email);
        }

        public IEnumerable<IUser> FindByCategory(UserType userType)
        {
            switch (userType)
            {
                case UserType.Customer:
                    return UserData.UserList.Where(c => c is Customer).ToList();
                case UserType.Manager:
                    return UserData.UserList.Where(r => r is Manager).ToList();
                default:
                    return null;
            }
        }

        public IEnumerable<IUser> FindByName(string name)
        {
            return UserData.UserList.Where(u => u.FirstName == name || u.LastName == name).ToList();
        }
    }
}
