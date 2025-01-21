using Practice_9;

namespace Practice_9_StudentManagerTests
{
    public class StudentManagerTests
    {
        private StudentManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new StudentManager();
        }

        [Test]
        public void AddStudent_ShouldAddStudentToList()
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 2 });

            var students = _manager.GetStudents();
            Assert.That(students, Does.Contain("Alice - Средний балл: 4"));
        }

        [Test]
        public void RemoveStudent_ShouldRemoveExistingStudent() ////негативный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            var result = _manager.RemoveStudent("Alice");


            Assert.That(result, Is.True);
            Assert.That(_manager.GetStudents(), Does.Not.Contain("Alice"));
        }

        [Test]
        public void UpdateStudent_ShouldUpdateGradesForExistingStudent()
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            var result = _manager.UpdateStudent("Alice", new List<int> { 5, 5, 5 });


            Assert.That(result, Is.True);
            Assert.That(_manager.GetStudents(), Does.Contain("Alice - Средний балл: 5"));
        }
    }
}