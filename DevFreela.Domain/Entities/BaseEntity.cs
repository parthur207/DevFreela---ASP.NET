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

        public bool SetAsDeleted()
        {
            if (IsDeleted is false) 
            {
                IsDeleted = true;
                return true;
            }
            return false;
        }

        public bool SetAsActive()
        {
            if (IsDeleted is true) 
            {
                IsDeleted = false;
                return true;
            }
            return false;
        }

    }
}
