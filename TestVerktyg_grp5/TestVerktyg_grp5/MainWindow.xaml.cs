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
        public MainWindow()
        {
            InitializeComponent();

            grid_loggedin.Visibility = Visibility.Visible; // ska vara hidden
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

            quiz.TimeToComplete = (int) slider.Value;


            if (showresult_cb.IsChecked != null) quiz.ShowResult = showresult_cb.IsChecked.Value;
        }

    }
}