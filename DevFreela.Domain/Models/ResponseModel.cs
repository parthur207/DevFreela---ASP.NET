namespace DevFreela.Domain.Models
{
    public class ResponseModel<T>
    {
        public ResponseModel() { }
       
        public T? Content { get; set; }
        public string? Message { get; set; }
        public bool Status { get; set; }
    }
}
