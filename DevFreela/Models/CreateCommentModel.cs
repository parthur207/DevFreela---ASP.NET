using DevFreela.Entities;

namespace DevFreela.Models
{
    public class CreateCommentModel
    {
        public string Content { get; set; }
        public int IdProject { get; set; }
        public int IdUser { get; set; }

        public ProjectCommentEntity ToCommentEntity()
            =>new (Content,IdProject, IdUser);
        
    }
}
    