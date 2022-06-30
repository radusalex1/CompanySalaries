namespace CompanySalaries.Models
{
    public class EmployeeWorkingWeek
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartWeek { get; set; }

        public int Day0 { get; set; }
        public int Day1 { get; set; }
        public int Day2 { get; set; }
        public int Day3 { get; set; }
        public int Day4 { get; set; }

        public int TotalSalaryPerWeek { get; set; }
        
        
    }
}
