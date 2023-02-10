using LearningCenter.Domain.Enteties;

namespace LearningCenter.Service.Helpers
{
    public class Response
    {
        //header
        public int StatusCode { get; set; } = 404;
        public string Message { get; set; } = "Not found";
        public bool IsOk { get; set; } = false;
        // body
        public Student Student { get; set; }

    }
}
