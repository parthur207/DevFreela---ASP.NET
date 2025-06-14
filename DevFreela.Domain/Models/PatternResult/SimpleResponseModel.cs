using DevFreela.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Models.ResponsePattern
{
    public class SimpleResponseModel
    {
        public SimpleResponseModel() { }

        public string? Message { get; set; }
        public ResponseStatusEnum Status { get; set; }
    }
}
