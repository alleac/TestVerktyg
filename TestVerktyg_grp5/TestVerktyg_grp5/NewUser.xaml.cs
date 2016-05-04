using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using TestVerktygLib;

namespace TestVerktyg_grp5
{
    /// <summary>
    /// Interaction logic for NewUser.xaml
    /// </summary>
    public partial class NewUser : Window
    {
        Repository Repo = new Repository();
        public NewUser()
        {
            InitializeComponent();
        }

        private void btn_newUser_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(tbx_firstName.Text) ||
                String.IsNullOrEmpty(tbx_lastName.Text) ||
                String.IsNullOrEmpty(tbx_eMail.Text) ||
                String.IsNullOrEmpty(tbx_password.Text)
                )
            {
                MessageBox.Show("All fields must be filled");
            }
            else
            {
                if (tbx_password.Text == tbx_repeatPassword.Text)
                {
                    var newUser = new User()
                    {
                        FirstName = tbx_firstName.Text,
                        LastName = tbx_lastName.Text,
                        Email = tbx_eMail.Text,
                        Password = tbx_password.Text,
                        IsAdmin = cbx_adminTeacher.IsChecked.Value
                    };


                    Repo.AddUser(newUser);

                    tbx_firstName.Text = "";
                    tbx_lastName.Text = "";
                    tbx_eMail.Text = "";
                    tbx_password.Text = "";
                    tbx_repeatPassword.Text = "";
                    cbx_adminTeacher.IsChecked = false;
                }
                else
                {
                    MessageBox.Show("Not the same password!");
                }
            }
        }
    }
}