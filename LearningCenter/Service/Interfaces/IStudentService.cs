using LearningCenter.Domain.Enums;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;

namespace LearningCenter.Service.Interfaces
{
    public interface IStudentService
    {
        Task<Response> AddAsync(StudentCreationDto student);
        Task<Response> ChangeAsync(StudentCreationDto student);
        Task<Response> RemoveAsync(int id);
        Task<Response> SelectByIdAsync(int id);
        Task<ListResponse> SelectAllAsync();
        Task<ListResponse> SelectAllBySubject(Subject subject);
        Task<ListResponse> SelectWarnedStudents();
    }
}
