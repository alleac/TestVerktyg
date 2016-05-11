using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestVerktygLib
{
    public static class UtilityTestVerktyg
    {
        public static Repository Repo { get; set; } = new Repository();
        public static ObservableCollection<Quiz> Quizzes { get; set; } 
        public static ObservableCollection<Question> QuizQuestions { get; set; } = new ObservableCollection<Question>();
        public static ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>(); 
        public static Quiz SelectedQuiz { get; set; }
        public static Question SelectedQuestion { get; set; }

        public static int SelectedQuizId { get; set; }
        public static int QuizLength { get; set; }
        public static int SelectedQuestionNumber { get; set; } = 0;

        public static List<Question> CurrentQuizQuestions { get; set; }
        public static int[] CurrentPoints { get; set; }
        public static int LoggedInUserId { get; set; }

        public static void GetQuizForUser()
        {
            Quizzes = Repo.GetQuizForUser(1);
        }

        public static void GetUsers()
        {
            Users = Repo.GetUsers();
        }
    }
}
