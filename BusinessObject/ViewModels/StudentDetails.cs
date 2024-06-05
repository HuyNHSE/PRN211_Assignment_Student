namespace BusinessObject.ViewModels
{
    public class StudentDetails
    {
        public int Id { get; set; }
        public string? Email { get; set; }

        public string? FullName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        //public int? GroupId { get; set; }
        public string GroupName { get; set; }
    }
}
