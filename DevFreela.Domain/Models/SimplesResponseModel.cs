using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Models
{
    public class SimpleResponseModel
    {
        public SimpleResponseModel() { }

        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
