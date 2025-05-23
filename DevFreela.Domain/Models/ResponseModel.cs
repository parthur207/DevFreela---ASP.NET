namespace DevFreela.Domain.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel() { }
        public ResponseModel(T? content, string? message, bool status)
        {
            Content = content;
            Message = message;
            Status = status;
        }

        public T? Content { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }

    public class SimpleResponseModel
    {
        public SimpleResponseModel() { }
        public SimpleResponseModel(string? message, bool status)
        {
            Message = message;
            Status = status;
        }

        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
