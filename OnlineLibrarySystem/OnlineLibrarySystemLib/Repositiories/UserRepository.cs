using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using OnlineLibrarySystemLib.Models.Data;

namespace OnlineLibrarySystemLib
{
    public class UserRepository : ILibraryRespository<IUser>, IBasicSearch<IUser, UserType>
    {
        public int Add(IUser item)
        {
            if (UserData.UserList.Exists(u => u.Email == item.Email))
                throw new ArgumentException("This user's email has already existed.");

            UserData.IncrementLastID();
            item.UserId = UserData.LastID;
            UserData.UserList.Add(item);

            return item.UserId;
        }

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

        public IEnumerable<IUser> GetAll()
        {
            return UserData.UserList.ToList();
        }

        public IUser GetByID(int id)
        {
            return UserData.UserList.FirstOrDefault(u => u.UserId == id);
        }

        public void RemoveByID(int id)
        {
            UserData.UserList.RemoveAll(u => u.UserId == id );
        }

        public IUser Update(IUser updatedUser)
        {
            if (updatedUser == null)
                throw new ArgumentException("Updated User is null.");

            var user = GetByID(updatedUser.UserId);

            if ( user == null )
                throw new ArgumentException("Invalid User Id.");

            user = updatedUser;

            return updatedUser;
        }

    }
}
