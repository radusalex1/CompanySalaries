namespace CompanySalaries.DTO
{
    public class EmployeeTaskDTO
    {
        public string EmployeeName { get; set; }
        public string ObjectiveName { get; set; }

        public DateTime StartWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public int WorkedHoursOnTask { get; set; } //(end time -  start time).h
        public int Done { get; set; } // for special tasks

    }
}
