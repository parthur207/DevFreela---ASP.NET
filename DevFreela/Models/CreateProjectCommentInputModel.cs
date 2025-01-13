namespace DevFreela.Models
{
    public class CreateProjectCommentInputModel
    {
        public string Content { get; set; }
        public string IdProject { get; set; }
        public int IdUser { get; set; }
    }
}
