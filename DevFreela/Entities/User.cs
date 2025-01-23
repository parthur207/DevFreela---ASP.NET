namespace DevFreela.Entities
{
    public class User : BaseEntity
    {
        public User(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Active = true;
        }

        public  string FullName { get; set; }

        public string Email { get; private set; }

        public DateTime BirthDate { get; set; }

        public bool Active { get; set; } 
    }
}
