using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Models.Creations
{
    public class CreateCommentModel
    {
        public string Content { get; set; }
        public int IdProject { get; set; }

    }
}
