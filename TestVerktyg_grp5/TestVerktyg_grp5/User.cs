using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktyg_grp5
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
        public bool IsAdmin { get; set; }

        public User(string firstName,
                    string lastName,
                    string email,
                    string password,
                    string repeatPassword
                    )
        //bool isAdmin
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = email;
            Password = password;
            RepeatPassword = repeatPassword;
            //IsAdmin = isAdmin;
        }
    }
}

