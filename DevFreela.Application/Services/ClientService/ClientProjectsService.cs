using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.ClientInterface;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.ClientService
{
    internal class ClientProjectsService : IClientProjectsInterface
    {
        public Task<SimpleResponseModel> BuyProjectClient(int IdUser, int IdProject)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> CancelPurchaseClient(int IdUser, int IdProject)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProjectDTO>>> GetPurchasedProjectsClient(int IdUser, string search, int Size)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> MakePaymentClient(int IdUser, int IdProject)
        {
            throw new NotImplementedException();
        }
    }
}
