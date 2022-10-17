using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;

namespace StudentDetails.Context
{
    public class MVCContext: DbContext
    {
        public MVCContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<StudentRecord> StudentDetails { get; set; }
    }
}
