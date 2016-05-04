using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string AnswerOne { get; set; }
        public string AnswerTwo { get; set; }
        public string AnswerThree { get; set; }
        public string AnswerFour { get; set; }
        public int RightAnswer { get; set; }
        public int HasAnsweredNumber { get; set; } = 0; // 0 is default
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }


    }
}
