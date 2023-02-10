using LearningCenter.Data.Configurations;
using LearningCenter.Data.IRepositories;
using LearningCenter.Domain.Enteties;
using Newtonsoft.Json;

namespace LearningCenter.Data.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly string path = DataBasePath.STUDENTS_PATH;
        private int LastId = 0;

        public async Task<Student> CreateAsync(Student student)
        {
            student.Id = LastId++;
            student.NowadaysTime = DateTime.Now;

            var values = await GetAllAsync();
            values.Add(student);

            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return student;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            List<Student> students = await GetAllAsync();
            var model = students.FirstOrDefault(p => p.Id == id);

            if (model is null) return false;

            students.Remove(model);

            var json = JsonConvert.SerializeObject(students, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return true;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            string models = await File.ReadAllTextAsync(path);

            if (string.IsNullOrEmpty(models))
            {
                File.WriteAllText(path, "[]");
                models = "[]";
            }
            List<Student> results = JsonConvert.DeserializeObject<List<Student>>(models);
            return results;
        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var students = await GetAllAsync();
            return students.FirstOrDefault(p => p.Id == id);
        }

        public async Task<Student> UpdateAsync(Student student)
        {
            var values = await GetAllAsync();
            var model = values.FirstOrDefault(p => p.Id == student.Id);

            if (model is null) return null;

            var index = values.IndexOf(model);
            values.Remove(model);

            student.PaidAt = model.PaidAt;
            student.UpdateAt = DateTime.UtcNow;

            values.Insert(index, student);
            var json = JsonConvert.SerializeObject(values, Formatting.Indented);
            await File.WriteAllTextAsync(path, json);
            return student;
        }
    }
}
