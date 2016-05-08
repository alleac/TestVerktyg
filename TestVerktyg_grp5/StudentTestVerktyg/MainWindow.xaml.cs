﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TestVerktygLib;

namespace StudentTestVerktyg
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Repository repo { get; set; } = new Repository();
        public List<Quiz> Quizzes { get; set; }

        private Quiz _selectedQuiz;

        public Quiz SelectedQuiz
        {
            get { return _selectedQuiz; }
            set { _selectedQuiz = value;}
        }



        public MainWindow()
        {
            
            InitializeComponent();
            QuizGrid.DataContext = this;
            Quizzes = repo.GetQuizzes();


        }

        private void btn_TakeQuiz_Click(object sender, RoutedEventArgs e)
        {
            //Update Utilityclass
            var quizWin = new QuizWindow();
            quizWin.Show();
        }
    }
}
