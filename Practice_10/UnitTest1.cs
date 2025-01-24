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
        public void AddTask_ShouldAddTaskWithDefaultStatus() // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var tasks = manager.GetTasks();
            Assert.That(tasks, Has.Count.EqualTo(1));
            Assert.That(tasks[0].Description, Is.EqualTo("Первая задача"));
            Assert.That(tasks[0].Status, Is.EqualTo("не начато"));
        }

        [Test]
        public void UpdateTaskStatus_ShouldChangeTaskStatus()  // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "в работе");
            var task = manager.GetTasks().First(t => t.Id == taskId);
            Assert.That(task.Status, Is.EqualTo("в работе"));
        }

        [Test]
        public void RemoveTask_ShouldRemoveTaskById()  // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var taskId = manager.GetTasks()[0].Id;
            manager.RemoveTask(taskId);
            Assert.That(manager.GetTasks(), Has.Count.EqualTo(0));
        }

        [Test]
        public void RemoveTask_ShouldNotChangeTaskList_WhenTaskDoesNotExist()  // Негативный сценарий
        {
            // Arrange
            var manager = new TaskManager();
            manager.AddTask("Первая задача");
            var initialCount = manager.GetTasks().Count;

            // Act
            manager.RemoveTask(Guid.NewGuid()); 

            // Assert
            Assert.That(manager.GetTasks(), Has.Count.EqualTo(initialCount)); 
        }

        [Test]
        public void UpdateTaskStatus_ShouldNotChangeStatus_WhenTaskDoesNotExist()  // Негативный сценарий
        {
            // Arrange
            var manager = new TaskManager();
            manager.AddTask("Первая задача");
            var initialStatus = manager.GetTasks()[0].Status;

            // Act
            manager.UpdateTaskStatus(Guid.NewGuid(), "в работе"); 

            // Assert
            var task = manager.GetTasks().First();
            Assert.That(task.Status, Is.EqualTo(initialStatus));
        }

        [Test]
        public void FilterTasksByStatus_ShouldReturnEmpty_WhenNoTasksMatch()  // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var filteredTasks = manager.FilterTasksByStatus("в работе");
            Assert.That(filteredTasks, Is.Empty);
        }

        [Test]
        public void FilterTasksByStatus_ShouldReturnMatchingTasks() // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "в работе");
            var filteredTasks = manager.FilterTasksByStatus("в работе");
            Assert.That(filteredTasks, Has.Count.EqualTo(1));
            Assert.That(filteredTasks[0].Description, Is.EqualTo("Первая задача"));
        }

        [Test]
        public void FilterTasksByStatus_ShouldBeCaseInsensitive() // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            var taskId = manager.GetTasks()[0].Id;
            manager.UpdateTaskStatus(taskId, "В РАБОТЕ");
            var filteredTasks = manager.FilterTasksByStatus("в работе");
            Assert.That(filteredTasks, Has.Count.EqualTo(1));
        }

        [Test]
        public void AddTask_ShouldAllowMultipleTasks() // Позитивный сценарий
        {
            manager.AddTask("Первая задача");
            manager.AddTask("Вторая задача");
            var tasks = manager.GetTasks();
            Assert.That(tasks, Has.Count.EqualTo(2));
        }

        [Test]
        public void RemoveTask_ShouldNotThrow_WhenRemovingNonExistentTask()// Негативный сценарий
        { 
            Assert.DoesNotThrow(() => manager.RemoveTask(Guid.NewGuid()));
        }
    }
}