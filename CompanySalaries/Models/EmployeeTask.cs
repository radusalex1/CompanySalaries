namespace CompanySalaries.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public TaskWork TaskWork { get; set; }

        public int WorkedHoursOnTask { get; set; }
        public int Done { get; set; }

    }
}
