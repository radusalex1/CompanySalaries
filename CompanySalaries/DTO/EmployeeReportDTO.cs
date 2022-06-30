namespace CompanySalaries.DTO
{
    public class EmployeeReportDTO
    {
        public string EmployeeName { get; set; }
        public string ProjectName { get; set; }
        public string ObjectiveName { get; set; }

        public int WorkedHours { get; set; }
        public int MoneyPerObjective { get; set; }
        public int WeeklySalary { get; set; }
    }
}
