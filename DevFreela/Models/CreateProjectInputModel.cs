namespace DevFreela.Models
{
    public class CreateProjectInputModel
    {

        public int Title { get; set; }
        public string Description { get; set; }
        public int IdClient { get; set; }
        public int IdFreeLancer { get; set; }
        public decimal TotalCost { get; set; }
    }
}
