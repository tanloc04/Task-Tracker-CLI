using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Tracker_CLI.Repositories;

namespace Task_Tracker_CLI.Commands
{
    public class AddCommand: ICommand
    {
        private readonly TaskRepository _repo;
        public AddCommand(TaskRepository repo)
        {
            _repo = repo;
        }

        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("[Error] Miss task description. Ex: task-cli add \"Mua rau\"");
                return;
            }

            var tasks = _repo.GetAllTasks();
            int newId = tasks.Count > 0 ? tasks[tasks.Count - 1].Id + 1 : 1;

            tasks.Add(
                new Models.TaskItem()
                {
                    Id = newId,
                    Description = args[1],
                    Status = "todo",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                });

            _repo.SaveAllTasks(tasks);
            Console.WriteLine($"Task added successfully (ID: {newId})");
        }
    }
}
