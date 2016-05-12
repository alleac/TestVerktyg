using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Console;
using static TestVerktygLib.UtilityTestVerktyg;

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

        public ObservableCollection<User> Users = new ObservableCollection<User>();

        public void AddUser(User user)
        {
            using (QuizDatabase db = new QuizDatabase()) 
            {
                db.Users.Add(user);
                db.SaveChanges();
            }
        }

        public ObservableCollection<User> GetUsers()
        {
            using (QuizDatabase db = new QuizDatabase())
            {
                foreach (var item in db.Users.ToList())
                {
                    Users.Add(item);
                }
                return Users;
            }
        }

        public void RemoveUser(User user)
        {
            using (var db = new QuizDatabase())
            {
                db.Users.Attach(user);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
        public void RemoveQuiz(Quiz quiz)
        {
            using (var db = new QuizDatabase())
            {
                db.Quizs.Attach(quiz);
                db.Quizs.Remove(quiz);
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
        public ObservableCollection<Quiz> GetQuizzes()
        {
            using (var db = new QuizDatabase())
            {
                return new ObservableCollection<Quiz>(db.Quizs.ToList());
            }
        }

        public List<Question> GetQuestionsForQuiz(int quizId)
        {
            using (var db = new QuizDatabase())
            {
                return db.Questions.Where(q => q.QuizId == quizId).ToList();
            }
        }

        public ObservableCollection<Quiz> GetQuizForUser(int userId)
        {
            using (var db = new QuizDatabase())
            {
                List<int> quizIdsList = db.Grades.Where(g => g.UserId == userId).Select(g => g.QuizId).ToList();

                return new ObservableCollection<Quiz>(db.Quizs.Where(q => !quizIdsList.Contains(q.Id))
                    .Where(q => q.CreationDate < DateTime.Now)
                    .Where(q => q.EndDate > DateTime.Now)
                    .ToList());
            }
        }

        public void SaveUserQuizScore(Grade userGrade)
        {
            using (var db = new QuizDatabase())
            {
                db.Grades.Add(userGrade);
                db.SaveChanges();
            }
        }

        public User CheckEmail(string email)
        {
            using (QuizDatabase db = new QuizDatabase())
            {
                return db.Users.FirstOrDefault(u => u.Email == email);
            }
        }

        public bool CheckEmailExicts(string email)
        {
            using (QuizDatabase db = new QuizDatabase())
            {
                return db.Users.Any(u => u.Email == email);
            }
        }

        public bool DoesGradeExcist(int quizId, int userId)
        {
            using (var db = new QuizDatabase())
            {
                return db.Grades.Any(g => g.QuizId == SelectedQuizId && g.UserId == LoggedInUserId);
            }
        }

        public ObservableCollection<Grade> GetUserGrade(int userId)
        {
            using (var db = new QuizDatabase())
            {
                return new ObservableCollection<Grade>(db.Grades.Include("Quiz").Where(g => g.UserId == userId));
                    
            }
        }
        public List<Grade> GetQuizStats()
        {
            using (var db = new QuizDatabase())
            {
                List<Grade> Grades = new List<Grade>();

                Grades = db.Grades.Include("Quiz").Include("User")
                    .OrderBy(g => g.Quiz.Id)
                    .ToList();

                return Grades;
            }
        }
    }
}
