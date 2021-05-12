using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManagement.DTO.Markses
{
    public class MarksSelectDTO
    {
        public enum MarksStatus
        {
            Pass,
            Failed
        }

        public int? StudentID { get; set; }
        public string StudentName { get; set; }
        public int? Score { get; set; }
        public int? Status { get; set; }
    }
}
