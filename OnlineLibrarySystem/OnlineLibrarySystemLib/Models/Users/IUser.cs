using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineLibrarySystemLib
{
    
    public interface IUser
    {
        int UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        Gender Gender { get; set; }
        DateTime DateOfBirth { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        Address Address { get; set; }
        Phone PhoneNumber { get; set; }
    }
}
