using BlazorAppMongoDB.Data;
using BlazorAppMongoDB.IService;

namespace BlazorAppMongoDB.PageClass
{
    public class StudentPage
    {
        IStudentService? studentService = null;

        public StudentPage(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        public string SaveInfo(byte[] fileBytes, Student student)
        {
            student.Photo = fileBytes;
            return studentService.Save(student);
        }

        public Student GetStudent(string studentId)
        {
            var student = studentService.GetStudent(studentId);
            if (student.Photo != null)
            {
                student.Photo = this.GetImage(Convert.ToBase64String(student.Photo));
                student.ImageUrl = string.Format("data:image/jpg;base64,{0}", Convert.ToBase64String(student.Photo));
                return student;
            }
            return student;
        }

        public byte[] GetImage(string sBase64String)
        {
            byte[] bytes = null;
            if (!string.IsNullOrEmpty(sBase64String))
            {
                bytes = Convert.FromBase64String(sBase64String);
            }
            return bytes;
        }
    }
}