using CompanySalaries.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanySalaries.DBContext
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options):base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskWork> TasksWork { get; set; }
        public DbSet<EmployeeWorkingWeek> EmployeesWorkingWeek { get; set; }
        public DbSet<EmployeeTask> EmployeesTask { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Employee>().ToTable("Employees");
            model.Entity<TaskWork>().ToTable("TasksWork");
            model.Entity<EmployeeWorkingWeek>().ToTable("EmployeesWorkingWeek");
            model.Entity<EmployeeTask>().ToTable("EmployeesTask");

        }
    }
}
