namespace DevFreela.Application.Models
{
    public class ResponseModel <T>
    {
        public string? Content { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; } = true;
    }
}
