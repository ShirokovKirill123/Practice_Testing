using Practic_9;

namespace StudentManagerTests
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
        public void AddStudent_ShouldAddStudentToList()   // Позитивный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 2 });

            var students = _manager.GetStudents();
            Assert.That(students, Does.Contain("Alice - Средний балл: 4"));
        }

        [Test]
        public void RemoveStudent_ShouldRemoveExistingStudent()  // Позитивный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            var result = _manager.RemoveStudent("Alice");


            Assert.That(result, Is.True);
            Assert.That(_manager.GetStudents(), Does.Not.Contain("Alice"));
        }

        [Test]
        public void UpdateStudent_ShouldUpdateGradesForExistingStudent() // Позитивный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            var result = _manager.UpdateStudent("Alice", new List<int> { 5, 5, 5 });


            Assert.That(result, Is.True);
            Assert.That(_manager.GetStudents(), Does.Contain("Alice - Средний балл: 5"));
        }

        [Test]
        public void RemoveStudent_ShouldReturnFalse_WhenStudentDoesNotExist() // Негативный сценарий
        {
            var result = _manager.RemoveStudent("Bob");

            Assert.That(result, Is.False);
        }

        [Test]
        public void UpdateStudent_ShouldReturnFalse_WhenStudentDoesNotExist() // Негативный сценарий
        {
            var result = _manager.UpdateStudent("Bob", new List<int> { 5, 5, 5 });

            Assert.That(result, Is.False);
        }

        [Test]
        public void GetTotalStudents_ShouldReturnCorrectCount() // Позитивный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            _manager.AddStudent("Bob", new List<int> { 3, 3, 3 });

            var totalStudents = _manager.GetTotalStudents();

            Assert.That(totalStudents, Is.EqualTo(2));
        }

        [Test]
        public void GetSortedStudentsByAverageGrade_ShouldReturnStudentsInDescendingOrder() // Позитивный сценарий
        {
            _manager.AddStudent("Alice", new List<int> { 4, 5, 3 });
            _manager.AddStudent("Bob", new List<int> { 5, 5, 5 });

            var sortedStudents = _manager.GetSortedStudentsByAverageGrade();

            Assert.That(sortedStudents.First(), Is.EqualTo("Bob - Средний балл: 5"));
            Assert.That(sortedStudents.Last(), Is.EqualTo("Alice - Средний балл: 4"));
        }

        [Test]
        public void GetSortedStudentsByAverageGrade_ShouldReturnEmpty_WhenNoStudentsExist() // Негативный сценарий
        {
            var sortedStudents = _manager.GetSortedStudentsByAverageGrade();

            Assert.That(sortedStudents, Is.Empty);
        }

        [Test]
        public void AddStudent_ShouldHandleStudentWithMinimumAverageGrade() // Позитивный сценарий
        {
            _manager.AddStudent("Charlie", new List<int> { 2, 2, 2 });

            var students = _manager.GetStudents();
            Assert.That(students, Does.Contain("Charlie - Средний балл: 2"));
        }

        [Test]
        public void AddStudent_ShouldHandleDuplicateGrades()  // Негативный сценарий
        {
            _manager.AddStudent("Bob", new List<int> { 5, 5, 5 });

            var students = _manager.GetStudents();
            Assert.That(students, Does.Contain("Bob - Средний балл: 5"));
        }
    }
}