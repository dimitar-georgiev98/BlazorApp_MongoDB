using BlazorAppMongoDB.Data;

namespace BlazorAppMongoDB.IService
{
    public interface IStudentService
    {
        string Save(Student student);
        List<Student> GetStudents();
        Student GetStudent(string studentId);
        string Delete(string studentId);
    }
}