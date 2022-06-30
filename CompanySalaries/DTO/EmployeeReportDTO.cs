namespace CompanySalaries.DTO
{
    public class EmployeeReportDTO
    {
        public string EmployeeName { get; set; }
        public List<ObjectiveReportDTO> objectiveReportDTOs { get; set; }
        public int WeeklySalary { get; set; }
    }
}
