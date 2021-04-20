using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.Models
{
    public class FacultySubject
    {
        public int ID { get; set; }
        [ForeignKey("Faculty")]
        public int FacultyID { get; set; }
        [ForeignKey("Subject")]
        public int SubjectID { get; set; }
    }
}
