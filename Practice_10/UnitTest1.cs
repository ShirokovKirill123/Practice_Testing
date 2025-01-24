namespace Practice_10
{
    public class Tests
    {
        private TaskManager manager;

        [SetUp]
        public void Setup()
        {
            manager = new TaskManager();
        }

        [Test]
        public void AddTask_ShouldAddTaskWithDefaultStatus() // ���������� ��������
        {
            manager.AddTask("������ ������");
            var tasks = manager.GetTasks();
            Assert.That(tasks, Has.Count.EqualTo(1));
            Assert.That(tasks[0].Description, Is.EqualTo("������ ������"));
            Assert.That(tasks[0].Status, Is.EqualTo("�� ������"));
        }

        [Test]
        public void UpdateTaskStatus_ShouldChangeTaskStatus()  // ���������� ��������
        {
            manager.AddTask("������ ������");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "� ������");
            var task = manager.GetTasks().First(t => t.Id == taskId);
            Assert.That(task.Status, Is.EqualTo("� ������"));
        }

        [Test]
        public void RemoveTask_ShouldRemoveTaskById()  // ���������� ��������
        {
            manager.AddTask("������ ������");
            var taskId = manager.GetTasks()[0].Id;
            manager.RemoveTask(taskId);
            Assert.That(manager.GetTasks(), Has.Count.EqualTo(0));
        }

        [Test]
        public void RemoveTask_ShouldNotChangeTaskList_WhenTaskDoesNotExist()  // ���������� ��������
        {
            // Arrange
            var manager = new TaskManager();
            manager.AddTask("������ ������");
            var initialCount = manager.GetTasks().Count;

            // Act
            manager.RemoveTask(Guid.NewGuid()); 

            // Assert
            Assert.That(manager.GetTasks(), Has.Count.EqualTo(initialCount)); 
        }

        [Test]
        public void UpdateTaskStatus_ShouldNotChangeStatus_WhenTaskDoesNotExist()  // ���������� ��������
        {
            // Arrange
            var manager = new TaskManager();
            manager.AddTask("������ ������");
            var initialStatus = manager.GetTasks()[0].Status;

            // Act
            manager.UpdateTaskStatus(Guid.NewGuid(), "� ������"); 

            // Assert
            var task = manager.GetTasks().First();
            Assert.That(task.Status, Is.EqualTo(initialStatus));
        }

        [Test]
        public void FilterTasksByStatus_ShouldReturnEmpty_WhenNoTasksMatch()  // ���������� ��������
        {
            manager.AddTask("������ ������");
            var filteredTasks = manager.FilterTasksByStatus("� ������");
            Assert.That(filteredTasks, Is.Empty);
        }

        [Test]
        public void FilterTasksByStatus_ShouldReturnMatchingTasks() // ���������� ��������
        {
            manager.AddTask("������ ������");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "� ������");
            var filteredTasks = manager.FilterTasksByStatus("� ������");
            Assert.That(filteredTasks, Has.Count.EqualTo(1));
            Assert.That(filteredTasks[0].Description, Is.EqualTo("������ ������"));
        }

        [Test]
        public void FilterTasksByStatus_ShouldBeCaseInsensitive() // ���������� ��������
        {
            manager.AddTask("������ ������");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "� ������");
            var filteredTasks = manager.FilterTasksByStatus("� ������");
            Assert.That(filteredTasks, Has.Count.EqualTo(1));
        }

        [Test]
        public void AddTask_ShouldAllowMultipleTasks() // ���������� ��������
        {
            manager.AddTask("������ ������");
            manager.AddTask("������ ������");
            var tasks = manager.GetTasks();
            Assert.That(tasks, Has.Count.EqualTo(2));
        }

        [Test]
        public void RemoveTask_ShouldNotThrow_WhenRemovingNonExistentTask()// ���������� ��������
        { 
            Assert.DoesNotThrow(() => manager.RemoveTask(Guid.NewGuid()));
        }
    }
}