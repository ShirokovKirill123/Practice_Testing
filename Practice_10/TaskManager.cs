using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_10
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();

        public void AddTask(string description)
        {
            tasks.Add(new Task { Id = Guid.NewGuid(), Description = description, Status = "не начато" });
        }

        public List<Task> GetTasks()
        {
            return tasks;
        }

        public void UpdateTaskStatus(Guid id, string newStatus)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                task.Status = newStatus;
            }
        }

        public void RemoveTask(Guid id)
        {
            tasks.RemoveAll(t => t.Id == id);
        }
        public List<Task> FilterTasksByStatus(string status)
        {
            return tasks.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void ExportTasksToCsv(string filePath)
        {
            var csvBuilder = new StringBuilder();
            csvBuilder.AppendLine("Id,Description,Status");

            foreach (var task in tasks)
            {
                csvBuilder.AppendLine($"{task.Id},{task.Description},{task.Status}");
            }

            File.WriteAllText(filePath, csvBuilder.ToString());
        }
    }
}
