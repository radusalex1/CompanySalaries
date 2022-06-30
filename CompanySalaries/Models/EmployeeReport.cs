namespace CompanySalaries.Models
{
    public class EmployeeReport
    {
        public int Id { get; set; }
        public List<EmployeeTask> EmployeeTasks { get; set; }   
        public int Salary { get; set; }
    }
}
