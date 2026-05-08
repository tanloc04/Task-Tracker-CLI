using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Tracker_CLI.Repositories;

namespace Task_Tracker_CLI.Commands
{
    public class UpdateCommand: ICommand
    {
        private readonly TaskRepository _repo;

        public UpdateCommand(TaskRepository repo)
        {
            _repo = repo;
        }

        public void Execute(string[] args)
        {
            if (args.Length < 3 || !int.TryParse(args[1], out int updateId))
            {
                Console.WriteLine("Wrong syntax. Ex: task-cli update 1 \"An toi\"");
                return;
            }

            var tasks = _repo.GetAllTasks();
            var taskToUpdate = tasks.Find(t => t.Id == updateId);

            if (taskToUpdate == null)
            {
                Console.WriteLine($"Not found the task with ID: {updateId}. Check again!");
                return;
            }

            taskToUpdate.Description = args[2];
            taskToUpdate.UpdatedAt = DateTime.Now;

            _repo.SaveAllTasks(tasks);
            Console.WriteLine($"Task (ID: {updateId}) updated successfully.");

        }
    }
}
