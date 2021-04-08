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
    public class UserRepository : ILibraryRespository<IUser>
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

            var oldUser = UserData.UserList
                .Find(u => u.UserId == updatedUser.UserId);

            oldUser = updatedUser;

            return updatedUser;
        }

        public IUser GetUserByEmail(string email)
        {
            return UserData.UserList.Find(u => u.Email == email);
        }

        public IEnumerable<IUser> GetUsersByCategory(UserType userType)
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

        public List<PropertyItem> GetUserDetails(int userID)
        {
            IUser user = GetByID(userID);
            if (user == null)
                throw new ArgumentException("Sorry. The item you requested is not available.");

            var properties = new List<PropertyItem>();

            foreach (var property in user.GetType().GetProperties())
            {
                StringBuilder sb = new StringBuilder();

                var charArray = (property.Name).ToCharArray();

                foreach (var letter in charArray)
                {
                    if (!Char.IsUpper(letter))
                        sb.Append(letter);
                    else
                        sb.Append(" " + letter);
                }

                properties.Add(
                    new PropertyItem(sb.ToString(), property.GetValue(user)));
            }

            var passwordProperty = properties.RemoveAll(p => p.Key == " Password");

            var dateOfBirthProperty = properties.Find(p => p.Key == " Date Of Birth");
            if (dateOfBirthProperty != null)
                dateOfBirthProperty.Value = ((DateTime)dateOfBirthProperty.Value).ToShortDateString();

            var addressProperty = properties.Find(p => p.Key == " Address");
            if (addressProperty.Value != null)
                addressProperty.Value = addressProperty.Value.ToString();

            properties.Sort((p, k) => p.Key.CompareTo(k.Key));

            return properties;
        }

    }
}
