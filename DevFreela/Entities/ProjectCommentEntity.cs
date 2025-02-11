namespace DevFreela.Entities
{
    public class ProjectCommentEntity : BaseEntity
    {
        public ProjectCommentEntity(string content, int idProject, int idUser) 
            : base()
        {
            Content = content;
            IdProject = idProject;
            IdUser = idUser;
        }

        public string Content { get; private set; }

        public int IdProject { get; private set; }

        public ProjectEntity Project { get; private set; }

        public int IdUser { get; private set; }
    }
}
