using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygLib;
using static TestVerktygLib.UtilityTestVerktyg;

namespace StudentTestVerktyg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<Quiz> Quizzes { get; set; }

        private Quiz _selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                if (value != null)
                {
                    _selectedQuiz = value;
                    SelectedQuizId = value.Id;
                    UtilityTestVerktyg.SelectedQuiz = value;
                }
                
            }
        }



        public MainWindow()
        {

            InitializeComponent();
            QuizGrid.DataContext = this;
            LoggedInUserId = 1; // CHANGE THAT MATCH THE LOGGED IN USER DYNAMICLY
            UtilityTestVerktyg.GetQuizForUser();
            lv_QuizList.ItemsSource = UtilityTestVerktyg.Quizzes;

            //Quizzes = repo.GetQuizForUser(1); // ***** CHANGE TO DEYNAMIC USERID *******


        }

        private void btn_TakeQuiz_Click(object sender, RoutedEventArgs e)
        {
            //Update Utilityclass
            var quizWin = new QuizWindow();
            quizWin.Closed += QuizQindowClosed;
            quizWin.Show();
        }

        private void QuizQindowClosed(object sender, EventArgs e)
        {
            MessageBox.Show(CurrentPoints.Sum().ToString());
            UtilityTestVerktyg.Quizzes.Remove(UtilityTestVerktyg.SelectedQuiz);
        }


    }
}
