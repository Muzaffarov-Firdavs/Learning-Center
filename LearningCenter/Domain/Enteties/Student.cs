using LearningCenter.Domain.Enums;

namespace LearningCenter.Domain.Enteties
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Subject Subject { get; set; }
        public DateTime PaidAt { get; set; }
        public DateTime NowadaysTime { get; set; }
        public DateTime? UpdateAt { get; set; }
    }
}
