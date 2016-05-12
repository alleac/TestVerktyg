using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
    public class Grade
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int QuizId { get; set; }
        public Quiz Quiz { get; set; }
        public string UserGrade { get; set; }
        public int? UserScore { get; set; }
        public DateTime CompletionDate { get; set; }
        public string TimeToComplete { get; set; }

    }
}
