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
        public DbSet<Objective> Objectives { get; set; }
        public DbSet<TypeOfObjective> TypeOfObjectives { get; set; }
        public DbSet<EmployeeWorkingWeek> EmployeesWorkingWeek { get; set; }
        public DbSet<EmployeeTask> EmployeesTask { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Employee>().ToTable("Employees");
            model.Entity<Project>().ToTable("Projects");
            model.Entity<Objective>().ToTable("Objectives");
            model.Entity<TypeOfObjective>().ToTable("TypeOfObjectives");
            model.Entity<EmployeeWorkingWeek>().ToTable("EmployeesWorkingWeek");
            model.Entity<EmployeeTask>().ToTable("EmployeesTask");
        }
    }
}
