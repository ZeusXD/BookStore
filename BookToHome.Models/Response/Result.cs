namespace BookToHome.Models
{
    public class Result<T>
    {
        public bool Successful {get;set;}
        public string Message {get;set;}
        public T Content {get;set;}
    }
}