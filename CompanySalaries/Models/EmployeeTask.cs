namespace CompanySalaries.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public Objective Objective { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int WorkedHoursOnTask { get; set; } //(end time -  start time).h
        public int Done { get; set; } // for special tasks

    }
}
