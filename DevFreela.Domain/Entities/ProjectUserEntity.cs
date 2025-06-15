using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Entities
{
    public class UserProjectEntity : BaseEntity
    {
        public int IdProject { get; set; }
        public ProjectEntity Project { get; set; }

        public int IdUser { get; set; }
        public UserEntity User { get; set; }

        public DateTime PurchaseDate { get; set; }

        public UserProjectEntity(int idProject, int idUser)
        {
            IdProject = idProject;
            IdUser = idUser;
            PurchaseDate = DateTime.Now;
        }
    }
}

