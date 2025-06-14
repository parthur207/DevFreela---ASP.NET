using DevFreela.Domain.Enums;

namespace DevFreela.Domain.Models.PatternResult
{
    public class ResponseModel<T>
    {
        public ResponseModel() { }

        public T? Content { get; set; }
        public string? Message { get; set; }
        public ResponseStatusEnum Status { get; set; }
    }
}
