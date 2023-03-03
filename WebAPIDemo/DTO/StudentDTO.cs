namespace WebAPIDemo.DTO
{
    public class StudentDTO
    {
        public int? Id { get; set; }
        public string? StudentId { get; set; }
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public int? CourseId { get; set; }
        public string? CourseName { get; set; } //do this if you want some of your properties to be OPTIONAL
        public DateTime? DateEnrolled { get; set; }
    }
}
