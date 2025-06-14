using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.ClientInterface
{
    public interface IClientProjectsInterface
    {

        //Querys
        Task<ResponseModel<List<ProjectDTO>>> GetPurchasedProjectsClient(int IdUser, int Size);

        //Commands
        Task<SimpleResponseModel> BuyProjectClient(int IdUser, int IdProject);
        Task<SimpleResponseModel> MakePaymentClient(int IdUser, int IdProject);
        Task<SimpleResponseModel> CancelProjectClient(int IdUser, int IdProject);

    }
}
