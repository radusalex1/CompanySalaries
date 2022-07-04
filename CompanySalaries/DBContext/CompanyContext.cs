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
        public DbSet<Project> Projects { get; set; }
        public DbSet<WorkTask> WorkTasks { get; set; }
        public DbSet<TypeOfWorkTask> TypeOfWorkTasks { get; set; }
        public DbSet<EmployeeTask> EmployeesTask { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Employee>().ToTable("Employees");
            model.Entity<Project>().ToTable("Projects");
            model.Entity<WorkTask>().ToTable("WorkTasks");
            model.Entity<TypeOfWorkTask>().ToTable("TypeOfWorkTasks");
            model.Entity<EmployeeTask>().ToTable("EmployeesTask");
        }
    }
}
