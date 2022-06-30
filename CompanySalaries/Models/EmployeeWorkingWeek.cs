namespace CompanySalaries.Models
{
    public class EmployeeWorkingWeek
    {
        public int Id { get; set; }
        public Employee Employee { get; set; }
        public DateTime StartWeek { get; set; }

        public int Day0 { get; set; } = 0; //data curenta - startweek
        public int Day1 { get; set; } = 0;
        public int Day2 { get; set; } = 0;
        public int Day3 { get; set; } = 0;
        public int Day4 { get; set; } = 0;

        public int TotalSalaryPerWeek { get; set; }//completat la finalul saptamanii;)
    }
}
