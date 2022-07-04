namespace CompanySalaries.Models
{
    public class EmployeeTask
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        public WorkTask WorkTask { get; set; }

        public DateTime StartWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        /// <summary>
        ///(end time -  start time).h -  not implemented
        /// </summary>
        public int WorkedHoursOnTask { get; set; } //(end time -  start time).h

        /// <summary>
        /// For special tasks.True is special task is done, otherwise false.
        /// </summary>
        public int Done { get; set; }

    }
}
