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
        public DateTime CreationDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TimeToComplete { get; set; } = 10; // 10 is default
        public int MaxPoints { get; set; }

    }
}
