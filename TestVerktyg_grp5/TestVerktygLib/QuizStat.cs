using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
    public class QuizStat
    {
        public string QuizName { get; set; }
        public int NumberofPassed { get; set; }
        public double AverageScore { get; set; }
        public TimeSpan AverageTimeToComplete { get; set; }


    }
}
