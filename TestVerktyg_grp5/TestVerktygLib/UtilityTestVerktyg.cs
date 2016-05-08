using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
   public static class UtilityTestVerktyg
    {
        public static int QuizLength { get; set; }
        public static int SelectedQuestionNumber { get; set; } = 0;
        
        public static List<Question> CurrentQuizQuestions { get; set; }
    }
}
