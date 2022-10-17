using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Models
{
    public class StudentRecord
    {
        [Key]
        public int StudentId { get; set; }

        public string? StudentName { get; set; }

        public int StudentMobile { get; set; }

        public string? StudentAddress { get; set; }

        public string? StudentDept { get; set; }
    }
}
