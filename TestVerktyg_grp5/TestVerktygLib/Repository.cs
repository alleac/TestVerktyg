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
                WriteLine(wasDbCreated ? "Database was created" : "Database already excists");
            }
            WriteLine("All done");
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

        public void RemoveUser(User user)
        {
            using (var db = new QuizDatabase())
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        public void AddQuiz(Quiz quiz)
        {
            using (var db = new QuizDatabase())
            {
                db.Quizs.Add(quiz);
                db.SaveChanges();
            }
        }
        public void AddQuestion(Question question)
        {
            using (var db = new QuizDatabase())
            {
                db.Questions.Add(question);
                db.SaveChanges();
            }
        }
        public List<Quiz> GetQuizzes()
        {
            using (var db = new QuizDatabase())
            {
                return db.Quizs.ToList();
            }
        }

        public List<Question> GetQuestionsForQuiz(int quizId)
        {
            using (var db = new QuizDatabase())
            {
                return db.Questions.Where(q => q.QuizId == quizId).ToList();
            }
        }

        public List<Quiz> GetQuizForUser(int userId)
        {
            using (var db = new QuizDatabase())
            {
                List<int> quizIdsList = db.Grades.Where(g => g.UserId == 1).Select(g => g.QuizId).ToList();


                return db.Quizs.Where(q => !quizIdsList.Contains(q.Id)).ToList();


            }
        }
    }
}
