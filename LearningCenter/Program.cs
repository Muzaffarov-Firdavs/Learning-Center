using LearningCenter.Data.Repositories;
using LearningCenter.Service.DTOs;
using LearningCenter.Service.Services;

namespace LearningCenter
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            StudentService check = new StudentService();
            StudentRepository studentRepository = new StudentRepository();

            var res = await check.ChangeAsync(new StudentCreationDto()
            {
                Name = "Test",
                Subject = Domain.Enums.Subject.Biology
            });

            Console.WriteLine(res.Message);

           
        }
    }
}