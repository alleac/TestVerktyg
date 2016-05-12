using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace TestVerktyg_grp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Repository Repo = new Repository();

        private User _selectedUser;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
            }
        }


        private Question _selectedQuestion;
        public Question SelectedQuestion
        {
            get { return _selectedQuestion; }
            set
            {
                if (value != null)
                {
                    _selectedQuestion = value;
                    UtilityTestVerktyg.SelectedQuestion = value;
                }
            }
        }

        private Quiz _selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set { _selectedQuiz = value; }
        }

        private Grade _userGrades;

        public Grade UserGrades
        {
            get { return _userGrades; }
            set { _userGrades = value; }
        }



        public MainWindow()
        {
            InitializeComponent();

            grid_loggedin.Visibility = Visibility.Hidden;

            DataContext = this;
            listViewQuestion.ItemsSource = UtilityTestVerktyg.QuizQuestions;
            UtilityTestVerktyg.GetUsers(); // Ropa på utility för att hämta users till utitlity.Users
            lv_userList.ItemsSource = UtilityTestVerktyg.Users; // binding för Utility.Users
            UtilityTestVerktyg.GetQuizForAdmin();
            lv_QuizList.ItemsSource = UtilityTestVerktyg.AdminQuizzes;

           lv_Statistiscs.ItemsSource=  Repo.GetQuizStats();
            
        }

        private void SwitchScreen()
        {
            grid_loggedin.Visibility = Visibility.Visible;
            grd_loginscreen.Visibility = Visibility.Hidden;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbx_inloggEmail.Text) ||
                String.IsNullOrEmpty(tbx_login.Password))
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                User user = Repo.CheckEmail(tbx_inloggEmail.Text);

                if (user != null)
                {
                    if (user.Password == tbx_login.Password &&
                        user.IsAdmin == true)
                    {
                        SwitchScreen();                       
                    }
                    else
                    {
                        MessageBox.Show("Wrong password");
                    }
                }
                else
                {
                    MessageBox.Show("User doesn't excist");
                }
            }
             
        }

        private void btn_newUser_Click(object sender, RoutedEventArgs e)
        {
            var createNewUserWindow = new NewUser();
            createNewUserWindow.Show();
        }

        private void btn_deleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedUser != null)
            {
                Repo.RemoveUser(_selectedUser);
                UtilityTestVerktyg.Users.Remove(_selectedUser);
                _selectedUser = null;
            }
            
        }

        private void Cq_btn_OnClick(object sender, RoutedEventArgs e)
        {
            var createNewQuestionWindow = new CreateQuestion();
            createNewQuestionWindow.Show();
        }

        private void cquiz_btn_Click(object sender, RoutedEventArgs e)
        {
            var quiz = new Quiz();
            if (qn_tbx.Text != "")
            {
                quiz.Name = qn_tbx.Text;
            }
            else
            {
                MessageBox.Show("Please enter a name for the Quiz");
                return;
            }
            
            if (start_dp.SelectedDate != null) quiz.CreationDate = start_dp.SelectedDate.Value;
            if (end_dp.SelectedDate != null) quiz.EndDate = end_dp.SelectedDate.Value;

            quiz.TimeToComplete = (slider.Value <= 0) ? 10 : (int)slider.Value;

            if (showresult_cb.IsChecked != null) quiz.ShowResult = showresult_cb.IsChecked.Value;

            if (UtilityTestVerktyg.QuizQuestions.Count > 1)
            {
                quiz.MaxPoints = UtilityTestVerktyg.QuizQuestions.Count();
                quiz.Questions = UtilityTestVerktyg.QuizQuestions.ToList();
                Repo.AddQuiz(quiz);
                UtilityTestVerktyg.AdminQuizzes.Add(quiz);
                UtilityTestVerktyg.QuizQuestions.Clear();
                UtilityTestVerktyg.CreateQuestionNumber = 1;

                qn_tbx.Text = "";
                start_dp.SelectedDate = DateTime.Now;
                end_dp.SelectedDate = DateTime.Now.AddDays(7);
                slider.Value = 0;
                showresult_cb.IsChecked = false;
               
            }
            else
            {
                MessageBox.Show("please enter atleast two questions");
            }
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            UtilityTestVerktyg.QuizQuestions.Remove(_selectedQuestion);
        }

        private void btn_DelQuiz_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedQuiz != null)
            {
                Repo.RemoveQuiz(_selectedQuiz);
                UtilityTestVerktyg.AdminQuizzes.Remove(_selectedQuiz);
                _selectedQuiz = null;
            }
            
        }
    }
}