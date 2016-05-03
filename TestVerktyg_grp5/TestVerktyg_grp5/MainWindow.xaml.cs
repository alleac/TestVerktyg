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

            grid_loggedin.Visibility = Visibility.Hidden;
        }

        private void SwitchScreen()
        {
            grid_loggedin.Visibility = Visibility.Visible;
            grd_loginscreen.Visibility = Visibility.Hidden;
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (tbx_login.Text == "admin" ||
                tbx_login.Text == "Admin")
            {
                SwitchScreen();
            }
            else
            {
                MessageBox.Show("Error password");
            }
        }

        private void btn_newUser_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbx_firstName.Text) ||
                String.IsNullOrEmpty(tbx_lastName.Text) ||
                String.IsNullOrEmpty(tbx_eMail.Text) ||
                String.IsNullOrEmpty(tbx_password.Text) ||
                String.IsNullOrEmpty(tbx_repeatPassword.Text)
                )
            {
                MessageBox.Show("Fyll i alla fälten");
            }
            else
            {
                Repo.AddUser(tbx_firstName.Text,
                             tbx_lastName.Text,
                             tbx_eMail.Text,
                             tbx_password.Text,
                             tbx_repeatPassword.Text
                             );

                tbx_firstName.Text = "";
                tbx_lastName.Text = "";
                tbx_eMail.Text = "";
                tbx_password.Text = "";
                tbx_repeatPassword.Text = "";
            }
        }
    }
}