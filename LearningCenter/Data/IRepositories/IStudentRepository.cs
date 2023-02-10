using LearningCenter.Domain.Enteties;

namespace LearningCenter.Data.IRepositories
{
    public interface IStudentRepository
    {
        Task<Student> CreateAsync(Student student);
        Task<Student> UpdateAsync(Student student);
        Task<bool> DeleteAsync(int id);
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync();
    }
}
