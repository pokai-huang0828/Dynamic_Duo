using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace OnlineLibrarySystemLib
{
    public class UserRepository : ILibraryRespository<IUser>, IBasicSearch<IUser, UserType>
    {
        private List<IUser> _list = GetUsers();

        private static List<IUser> GetUsers()
        {
            return new List<IUser>
            {
                new Customer(){
                    FirstName = "Pokai", 
                    LastName="Haung", 
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1992,8,24),
                    Email = "pokai@library.com"
                },
                new Customer(){
                    FirstName = "David", 
                    LastName="Koo", 
                    Gender = Gender.Male,
                    DateOfBirth = new DateTime(1995,3,20),
                    Email = "david@library.com"
                },
                new Manager(){
                    FirstName = "Mimi", 
                    LastName="Omg", 
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1987,9,20),
                    Email = "mimi@library.com"
                },
                new Manager(){
                    FirstName = "Kelly", 
                    LastName="Lewis", 
                    Gender = Gender.Female,
                    DateOfBirth = new DateTime(1970,1,6),
                    Email = "Kelly@library.com"
                }
            };
        }

        private static UserRepository _instance;
        private static int _lastID = 0;

        private UserRepository() { }

        public static UserRepository Instance 
        { 
            get { return _instance ?? new UserRepository(); }
        }

        public int Add(IUser item)
        {
            item.UserId = ++_lastID;
            _list.Add(item);

            return item.UserId;
        }

        public IEnumerable<IUser> FindByCategory(UserType userType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IUser> FindByName(string name)
        {
            return _list.Where(u => u.FirstName == name || u.LastName == name);
        }

        public IEnumerable<IUser> GetAll()
        {
            return _list;
        }

        public IUser GetByID(int id)
        {
            return _list.FirstOrDefault(u => u.UserId == id);
        }

        public void RemoveByID(int id)
        {
            _list.RemoveAll(u => u.UserId == id );
        }

        public IUser Update(int id, IUser updatedItem)
        {
            if (updatedItem == null)
                throw new ArgumentNullException();


            
            throw new NotImplementedException();
        }
    }
}
