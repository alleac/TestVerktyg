using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktygLib
{
    public class Quiz
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = new DateTime(9999,12,12);
        public int TimeToComplete { get; set; } = 10; // 10 is default time to complete test if nothing overrides it
        public int MaxPoints { get; set; }
        public bool ShowResult { get; set; }
        public virtual List<Question> Questions { get; set; } 


    }
}
