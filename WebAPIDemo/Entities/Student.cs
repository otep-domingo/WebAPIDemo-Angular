namespace WebAPIDemo.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Course { get; set; }
        public DateTime DateEnrolled { get; set; }
    }
}
