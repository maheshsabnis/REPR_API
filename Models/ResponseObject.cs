namespace REPR_API.Models
{
    public class ResponseObject<T> where T: EntityBase
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public IEnumerable<T> Records { get; set; } = Enumerable.Empty<T>();
        public T? Record { get; set; }    
    }
}
