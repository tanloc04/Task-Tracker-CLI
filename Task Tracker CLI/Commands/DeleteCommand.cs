using Task_Tracker_CLI.Repositories;

namespace Task_Tracker_CLI.Commands
{
    public class DeleteCommand: ICommand
    {
        private readonly TaskRepository _repo;
        public DeleteCommand(TaskRepository repo)
        {
            _repo = repo;
        }
        public void Execute(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("[Error] Wrong syntax of command. Ex: task-cli delete 1");
                return;
            }

            if (!int.TryParse(args[1], out int deleteId))
            {
                Console.WriteLine("[Error] The ID you give wrong type. Ex: task-cli delete 1, task-cli delete 100,...");
                return;
            }

            var tasks = _repo.GetAllTasks();
            var taskToDelete = tasks.Find(t => t.Id == deleteId);

            if (taskToDelete == null)
            {
                Console.WriteLine($"[Error] The task you found with ID: {deleteId} is not available. Check again!");
                return;
            }

            tasks.Remove(taskToDelete);
            _repo.SaveAllTasks(tasks);
            Console.WriteLine($"Task (ID: {deleteId}) deteled successfully.");
        }
    }
}
