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
            WriteLine("Does database excist?");

            using (QuizDatabase db = new QuizDatabase())
            {
                bool wasDbCreated = db.Database.CreateIfNotExists();
                WriteLine(wasDbCreated ? "Database was created" : "database excists");
            }
            WriteLine("done...");
        }

        public List<User> Users;


        public void AddUser(User user)
        {
            using (QuizDatabase db = new QuizDatabase()) 
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }
    }
}
