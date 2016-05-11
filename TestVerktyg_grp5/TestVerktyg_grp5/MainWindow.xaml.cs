﻿using System;
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

        public MainWindow()
        {
            InitializeComponent();

            grid_loggedin.Visibility = Visibility.Visible; // ska vara hidden

            DataContext = this;
            listViewQuestion.ItemsSource = UtilityTestVerktyg.QuizQuestions;
            UtilityTestVerktyg.GetUsers(); // Ropa på utility för att hämta users till utitlity.Users
            lv_userList.ItemsSource = UtilityTestVerktyg.Users; // binding för Utility.Users


        }

        private void SwitchScreen()
        {
            grid_loggedin.Visibility = Visibility.Visible;
            //grd_loginscreen.Visibility = Visibility.Hidden;
        }

        //private void btn_login_Click(object sender, RoutedEventArgs e)
        //{
        //    if (tbx_login.Text == "admin" ||
        //        tbx_login.Text == "Admin")
        //    {
        //        SwitchScreen();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error password");
        //    }
        //}

        private void btn_newUser_Click(object sender, RoutedEventArgs e)
        {
            var createNewUserWindow = new NewUser();
            createNewUserWindow.Show();
        }

        private void btn_deleteUser_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cq_btn_OnClick(object sender, RoutedEventArgs e)
        {
            var createNewQuestionWindow = new CreateQuestion();
            createNewQuestionWindow.Show();
        }

        private void cquiz_btn_Click(object sender, RoutedEventArgs e)
        {
            var quiz = new Quiz();
            quiz.Name = qn_tbx.Text;
            if (start_dp.SelectedDate != null) quiz.CreationDate = start_dp.SelectedDate.Value;
            if (end_dp.SelectedDate != null) quiz.EndDate = end_dp.SelectedDate.Value;

            quiz.TimeToComplete = (slider.Value <= 0) ? 10 : (int)slider.Value;

            if (showresult_cb.IsChecked != null) quiz.ShowResult = showresult_cb.IsChecked.Value;

            Console.WriteLine(quiz.Name);
            Console.WriteLine(quiz.CreationDate);
            Console.WriteLine(quiz.EndDate);
            Console.WriteLine(quiz.TimeToComplete);
            Console.WriteLine(quiz.ShowResult);
        }

        private void del_btn_Click(object sender, RoutedEventArgs e)
        {
            UtilityTestVerktyg.QuizQuestions.Remove(_selectedQuestion);
        }
    }
}