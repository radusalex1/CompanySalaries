namespace CompanySalaries.DTO
{
    public class EmployeeTaskDTO
    {
        public int EmployeeId { get; set; }
        public int WorkTaskId { get; set; }

        public DateTime StartWeek { get; set; }
      
        public int WorkedHoursOnTask { get; set; }
        public int Done { get; set; } // for special tasks

    }
}
