using DevFreela.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace DevFreela.Domain.Models
{
    public class CreateProjectModel
    {
        [Required(ErrorMessage ="É obrigatório o informe de um título para o projeto.")]
        [StringLength(100, ErrorMessage = "O título deve ter no máximo 70 caracteres.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "É obrigatório o informe de uma descrição para o projeto.")]
        [StringLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Description { get; set; }

        public decimal TotalCost { get; set; }  
    }
}
