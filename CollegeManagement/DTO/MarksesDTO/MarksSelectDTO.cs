namespace CollegeManagement.DTO.MarksesDTO
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
        public string StudentCode { get; set; }
        public int? Score { get; set; }
        public int? Status { get; set; }
    }
}
