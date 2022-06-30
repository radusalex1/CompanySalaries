namespace CompanySalaries.Models
{
    public class Objective
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfObjective TypeOfObjective { get; set; }
        public int Price { get; set; }
        public Project Project { get; set; }
    }
}
