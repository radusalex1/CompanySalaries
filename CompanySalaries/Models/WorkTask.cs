namespace CompanySalaries.Models
{
    public class WorkTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypeOfWorkTask TypeOfWorkTask { get; set; }
        public int Price { get; set; }
        public Project Project { get; set; }
    }
}
