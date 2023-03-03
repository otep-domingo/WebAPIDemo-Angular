namespace WebAPIDemo.Entities
{
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public string StudentName { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }
}
