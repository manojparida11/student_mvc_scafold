using System;
using System.Collections.Generic;

namespace StudentDetails.Models
{
    public partial class StudentTable
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mobile { get; set; }
        public string? Address { get; set; }
        public string? Department { get; set; }
    }
}
