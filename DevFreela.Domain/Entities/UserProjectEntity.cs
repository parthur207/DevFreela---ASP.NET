using DevFreela.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Entities
{
    public class UserProjectEntity : BaseEntity
    {
        public UserProjectEntity(int idProject, int idUser)
        {
            IdProject = idProject;
            IdUser = idUser;
            PurchaseDate = DateTime.Now;
        }

        public int IdProject { get; private set; }
        public ProjectEntity Project { get; private set; }

        public int IdUser { get; private set; }
        public UserEntity User { get; private set; }

        public PurchaseStatusEnum PurchaseStatus { get; private set; }
        public DateTime PurchaseDate { get; set; }


        public void AssignClient(int ClientId)
        {
            IdUser= ClientId;
        }


        public void SetPaymentPending()
        {
            PurchaseStatus = PurchaseStatusEnum.PaymentPending;
        }

        public void MakeAsSold()
        {
            if (PurchaseStatus == PurchaseStatusEnum.PaymentPending)
            {
                PurchaseStatus = PurchaseStatusEnum.Sold;
                PurchaseDate = DateTime.Now;
            }
        }

        public void CancelPurchase()
        {
            if (PurchaseStatus == PurchaseStatusEnum.PaymentPending)
            {
                PurchaseStatus = PurchaseStatusEnum.PurchaseCanceled;
            }
        }
    }
}

