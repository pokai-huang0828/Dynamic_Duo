using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystem
{
    public class UserList : IEnumerable
    {
        private List<User> _listOfUser;
        private int _lastUserID;

        public UserList()
        {
            _listOfUser = new List<User>();
            _lastUserID = 0;
        }

        public User SearchUserById(int userID)
        {
            return _listOfUser.FirstOrDefault(user => user.UserId == userID);
        }
        
        public List<User> SearchUsersByUserType(string userType)
        {
            if (userType.ToLower() == "customer")
                return _listOfUser.Where(u => u is Customer).ToList();
            else if (userType.ToLower() == "manager")
                return _listOfUser.Where(u => u is Manager).ToList();
            else
                return default(List<User>);
        }

        public void AddUser(User u)
        {
            u.UserId = ++_lastUserID;
            _listOfUser.Add(u);
        }

        public void RemoveUser(int userID)
        {
            _listOfUser.RemoveAll(u => u.UserId == userID);
        }

        public IEnumerator GetEnumerator()
        {
            foreach (User u in _listOfUser)
            {
                yield return u;
            }
        }

    }
}
