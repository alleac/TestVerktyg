using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        public User(string firstName,
                    string lastName,
                    string email,
                    string password
                    )
        //bool isAdmin
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            //IsAdmin = isAdmin;
        }

        public User()
        {
                
        }
    }
}
