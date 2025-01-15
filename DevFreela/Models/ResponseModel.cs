namespace DevFreela.Models
{
    public class ResponseModel <T>
    {
        public string? Content { get; set; }
        public string? Message { get; set; }
        public bool status { get; set; } = true;
    }
}
