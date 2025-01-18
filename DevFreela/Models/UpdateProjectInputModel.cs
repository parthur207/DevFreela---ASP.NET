namespace DevFreela.Models
{
    public class UpdateProjectInputModel
    {
        public int IdProject { get; set; }

        public string Title { get; set; }

        public string Descption { get; set; }

        public decimal TotalCost { get; set; }
    }
}
