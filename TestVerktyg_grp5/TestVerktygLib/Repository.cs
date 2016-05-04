using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;

namespace TestVerktygLib
{
    public class Repository
    {
        public Repository()
        {
            WriteLine("Kollar om databasen existerar.");

            using (QuizDatabase db = new QuizDatabase())
            {
                bool wasCreated = db.Database.CreateIfNotExists();
                if (wasCreated)
                    WriteLine("Databasen skapades.");
                else
                    WriteLine("Databasen finns redan.");
            }
            WriteLine("Klar.");
        }

        public List<User> Users = new List<User>();

        public bool CheckIdNumber(int ID)
        {
            using (QuizDatabase db = new QuizDatabase()) //Är detta rätt?
            {
                foreach (User User in Users)
                {
                    if (User.User_ID == ID)
                    {
                        MessageBox.Show("Användaren finns redan!");
                        return true;
                    }
                }
            }
            MessageBox.Show("Användaren finns inte!");

            return false;
        }

        public User AddUser(string firstName,
                            string lastName,
                            string email,
                            string password,
                            string repeatPassword
                            )
        //bool isAdmin
        {
            using (QuizDatabase db = new QuizDatabase()) // Connect to database.
            {

                User newUser;

                //if (CheckIdNumber())
                //{
                //    newCustomer = null;
                //}
                //else
                //{
                newUser = new User(firstName,
                                   lastName,
                                   email,
                                   password
                                   );
                //isAdmin
                db.Users.Add(newUser);

                db.SaveChanges();
                //}
                return newUser;
            }
        }
    }
}
