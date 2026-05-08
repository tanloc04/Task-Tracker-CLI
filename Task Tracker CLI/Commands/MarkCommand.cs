using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Tracker_CLI.Repositories;

namespace Task_Tracker_CLI.Commands
{
    public class MarkCommand: ICommand
    {
        private readonly TaskRepository _repo;
        private readonly string _targertStatus;

        public MarkCommand(TaskRepository repo, string targertStatus)
        {
            _repo = repo;
            _targertStatus = targertStatus;
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2 || !int.TryParse(args[1], out int markId))
            {
                Console.WriteLine($"[Error] Wrong syntax. Ex: task-cli mark-{_targertStatus} 1");
                return;
            }

            var tasks = _repo.GetAllTasks();
            var taskToMark = tasks.Find(t => t.Id == markId);

            if (taskToMark == null)
            {
                Console.WriteLine($"[Error] Not found the task with ID: {markId}");
                return;
            }

            taskToMark.Status = _targertStatus;
            taskToMark.UpdatedAt = DateTime.Now;

            _repo.SaveAllTasks(tasks);
            Console.WriteLine($"Task (ID: {markId}) marked as {_targertStatus} successfully.");
        }
    }
}
