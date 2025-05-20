namespace DevFreela.Application.Models
{
    public class ResponseModel <T>
    {
        public ResponseModel(T? content, string? message, bool status)
        {
            Content = content;
            Message = message;
            Status = status;
        }

        public T? Content { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; } = true;
    }
}
