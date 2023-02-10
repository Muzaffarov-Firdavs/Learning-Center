using LearningCenter.Data.IRepositories;
using LearningCenter.Data.Repositories;
using LearningCenter.Domain.Enteties;
using LearningCenter.Domain.Enums;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Helpers;
using LearningCenter.Service.Interfaces;

namespace LearningCenter.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository = new StudentRepository();

        public async Task<Response> AddAsync(StudentCreationDto student)
        {
            var models = await studentRepository.GetAllAsync();
            var entity = models.FirstOrDefault(p => p.Name == student.Name);

            if (entity is not null) return new Response();

            var model = new Student()
            {
                Name = student.Name,
                Subject = student.Subject
            };

            var result = await studentRepository.CreateAsync(model);

            return new Response()
            {
                StatusCode = 200,
                Message = "Succeess..!",
                IsOk = true,

                Student = result
            };
        }

        public async Task<Response> ChangeAsync(StudentCreationDto student)
        {
            var models = await studentRepository.GetAllAsync();
            var entity = models.FirstOrDefault(p => p.Name == student.Name);

            if (entity is not null) return new Response();

            var model = new Student()
            {
                Name = student.Name,
                Subject = student.Subject
            };

            var result = await studentRepository.UpdateAsync(model);

            return new Response()
            {
                StatusCode = 200,
                Message = "Success",
                IsOk = true,
                Student = model
            };
        }

        public async Task<Response> RemoveAsync(int id)
        {
            var model = await studentRepository.GetByIdAsync(id);
            if (model is not null) return new Response();

            await studentRepository.DeleteAsync(id);
            return new Response()
            {
                StatusCode = 200,
                Message = "Succeess..!",
                IsOk = true,
                Student = null
            };
        }

        public async Task<ListResponse> SelectAllAsync()
        {
            var results = await studentRepository.GetAllAsync();
            return new ListResponse()
            {
                StatusCode = 200,
                Message = "Success",
                Students = results
            };
        }

        public async Task<Response> SelectByIdAsync(int id)
        {
            var model = await studentRepository.GetByIdAsync(id);
            if (model is not null)
                return new Response()
                {
                    StatusCode = 200,
                    Message = "Success",
                    IsOk = true,
                    Student = model
                };
            return new Response();
        }

        public async Task<ListResponse> SelectAllBySubject(Subject subject)
        {
            var students = await studentRepository.GetAllAsync();
            var selectedStudents = new List<Student>();
            foreach (var student in students)
            {
                if (student.Subject == subject)
                {
                    selectedStudents.Add(student);
                }
            }

            if (selectedStudents.Count == 0) return new ListResponse();

            return new ListResponse()
            {
                StatusCode = 200,
                Message = "Success",
                Students = selectedStudents
            };
        }

        public async Task<ListResponse> SelectWarnedStudents()
        {
            var students = await studentRepository.GetAllAsync();
            var payingNearStudents = new List<Student>();

            foreach (var student in students)
            {
                var paidAt = student.PaidAt;
                var now = DateTime.UtcNow;
                TimeSpan paidTime = now - paidAt;
                if (paidTime.TotalDays > 26)
                {
                    payingNearStudents.Add(student);
                }
            }
            if (payingNearStudents.Count == 0) return new ListResponse();

            return new ListResponse()
            {
                StatusCode = 200,
                Message = "Success",
                Students = payingNearStudents
            };
        }
    }
}
