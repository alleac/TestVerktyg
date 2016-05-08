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
using System.Windows.Shapes;
using TestVerktygLib;

namespace StudentTestVerktyg
{
    /// <summary>
    /// Interaction logic for QuizWindow.xaml
    /// </summary>
    public partial class QuizWindow : Window, INotifyPropertyChanged
    {
        private Repository repo { get; set; } = new Repository();
        public List<Question> Questions { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Question _question;
        public Question Question
        {
            get
            {return _question;}

            set
            {
                _question = value;
                NotifyPropertyChanged(nameof(Question));

            }
        }

        public QuizWindow()
        {
            InitializeComponent();

            Questions = new List<Question>(repo.GetQuestionsForQuiz(1));


            Question = Questions[0];
            QuizWindowGrid.DataContext = this;
        }
        private void NotifyPropertyChanged(String prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Forward_Click(object sender, RoutedEventArgs e)
        {
            Question = Questions[1];
        }
    }
}
