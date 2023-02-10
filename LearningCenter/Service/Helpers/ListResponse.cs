using LearningCenter.Domain.Enteties;

namespace LearningCenter.Service.Helpers
{
    public class ListResponse
    {
        // header 
        public int StatusCode { get; set; }
        public string Message { get; set; }

        // body
        public List<Student> Students { get; set; }
    }
}
