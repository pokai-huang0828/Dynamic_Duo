using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib.Models.Data
{
    public class UserData
    {
        private static List<IUser> _list;
        private static int _lastID;

        private UserData() { }

        public static List<IUser> UserList
        {
            get
            {
                if (_list == null)
                {
                    _list = GetUsers();
                    _lastID = _list.Count;
                }
                return _list;
            }
        }

        public static int LastID => _lastID;

        public static void IncrementLastID()
        {
            ++_lastID;
        }

        private static List<IUser> GetUsers()
        {
            return new List<IUser>
            {
                new Customer( "pokai@library.com", "123"){
                    UserId = 1,
                    FirstName = "Pokai",
                    LastName="Haung",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1992,8,24)
                },
                new Customer("david@library.com", "123"){
                    UserId = 2,
                    FirstName = "David",
                    LastName="Koo",
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1995,3,20)
                },
                new Manager("mimi@library.com", "123"){
                    UserId = 3,
                    FirstName = "Mimi",
                    LastName="Omg",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1987,9,20)
                },
                new Manager( "kelly@library.com", "123"){
                    UserId = 4,
                    FirstName = "Kelly",
                    LastName="Lewis",
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1970,1,6)
                }
            };
        }



    }
}
