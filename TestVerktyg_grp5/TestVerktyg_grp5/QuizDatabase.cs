using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestVerktyg_grp5
{
    class QuizDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }
        public QuizDatabase() : base("dbTestApp") { }
    }
}
