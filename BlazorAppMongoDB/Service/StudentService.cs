using BlazorAppMongoDB.Data;
using BlazorAppMongoDB.IService;
using MongoDB.Driver;

namespace BlazorAppMongoDB.Service
{
    public class StudentService : IStudentService
    {
        Student student = new Student();

        private MongoClient mongoClient = null;
        private IMongoDatabase database = null;
        private IMongoCollection<Student> studentTable = null;

        public StudentService()
        {
            mongoClient = new MongoClient("mongodb+srv://Dimitar:Pass!234@cluster0.kggcy1s.mongodb.net/?retryWrites=true&w=majority");
            database = mongoClient.GetDatabase("SchoolDB");
            studentTable = database.GetCollection<Student>("Students");
        }

        public Student GetStudent(string studentId)
        {
            return studentTable.Find(x => x.Id == studentId).FirstOrDefault();
        }

        public List<Student> GetStudents()
        {
            return studentTable.Find(FilterDefinition<Student>.Empty).ToList();
        }

        public string Save(Student student)
        {
            var studentObj = studentTable.Find(x => x.Id == student.Id).FirstOrDefault();
            if (studentObj == null)
            {
                studentTable.InsertOne(student);
            }
            else
            {
                studentTable.ReplaceOne(x => x.Id == student.Id, student);
            }
            return "Saved";
        }
    }
}