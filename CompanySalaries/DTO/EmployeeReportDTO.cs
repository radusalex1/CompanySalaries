namespace CompanySalaries.DTO
{
    public class EmployeeReportDTO
    {
        public string EmployeeName { get; set; }
        public List<WorkTaskReportDTO> WorkTaskReportDTOs { get; set; }
        public int WeeklySalary { get; set; }
    }
}
