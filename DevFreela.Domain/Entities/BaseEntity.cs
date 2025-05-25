namespace DevFreela.Domain.Entities
{
    public abstract class BaseEntity
    {

        public BaseEntity()
        {
            CreatedAt = DateTime.Now;
            IsDeleted = false;
        }
        public int Id { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public bool IsDeleted { get; private set; } = false;

        public void SetAsDeleted()
        {
            IsDeleted = true;
        }

    }
}
