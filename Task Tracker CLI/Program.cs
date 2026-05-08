using System.Windows.Input;
using Task_Tracker_CLI.Commands;
using Task_Tracker_CLI.Models;
using Task_Tracker_CLI.Repositories;
using ICommand = Task_Tracker_CLI.Commands.ICommand;

namespace Task_Tracker_CLI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("[Alert] Please ");
            }

            string commandName = args[0].ToLower();
            TaskRepository repo = new TaskRepository();

            //Đóng vai trò như 1 cuốn từ điển, nhận vào 1 yêu cầu
            //tìm kiếm (Key) theo type nào, và cái cần tìm (Value) là type gì
            Dictionary<string, ICommand> commandDictionary = new Dictionary<string, ICommand>();

            commandDictionary.Add("add", new AddCommand(repo));
            commandDictionary.Add("delete", new DeleteCommand(repo));
            commandDictionary.Add("update", new UpdateCommand(repo));
            commandDictionary.Add("mark-in-progress", new MarkCommand(repo, "in-progress"));
            commandDictionary.Add("mark-done", new MarkCommand(repo, "done"));


            if (commandDictionary.ContainsKey(commandName))
            {
                ICommand selectedCommand = commandDictionary[commandName];
                selectedCommand.Execute(args);
            }
            else
            {
                Console.WriteLine($"[Error] Command is not supported!");
            }
        }

        // args (Arguments) chính là cầu nối của những gì mà user
        // gõ trên Terminal và Code C# của user
        //static void Main(string[] args)
        //{
        //    // Ex add a task: task-cli add "Buy groceries"
        //    // Lưu ý: task-cli thực chất là tên file .exe để
        //    // chương trình gọi app chạy lên nên nó ko đc tính
        //    // là 1 args!!!

        //    //Check xem người dùng có nhập lệnh ko
        //    if (args.Length == 0)
        //    {
        //        Console.WriteLine("Thong bao: Vui long nhap 1 cau lenh.");
        //        Console.WriteLine("Cach su dung task-cli <command> [arguments]");
        //        return;
        //    }

        //    //Lấy ra lệnh đầu tiên và ép nó về kiểu chữ thường, dù ADD -> add
        //    string command = args[0].ToLower();

        //    //Thuê 1 "ông thủ kho"
        //    TaskRepository repository = new TaskRepository();

        //    //Rẽ nhánh xử lý dựa vào lệnh
        //    switch (command)
        //    {
        //        case "add":
        //            //Lệnh add bắt buộc phải có nội dung (add "An com"), tức là
        //            //args phải có ít nhất 2 phần tử
        //            if (args.Length < 2)
        //            {
        //                Console.WriteLine("Loi: Thieu noi dung cong viec.");
        //                Console.WriteLine("Vi du: task-cli add \"Mua rau ngoai cho\"");
        //                break;
        //            }
        //            string description = args[1];

        //            //Thủ kho lôi sổ ra
        //            var tasks = repository.GetAllTasks();

        //            //Tính toán Id mới. Nếu sổ trống thì Id = 1, ngược lại Id to nhất + 1

        //            int newId = 1;
        //            if (tasks.Count > 0)
        //            {
        //                newId = tasks[tasks.Count - 1].Id + 1;
        //            }

        //            TaskItem newTask = new TaskItem
        //            {
        //                Id = newId,
        //                Description = description,
        //                CreatedAt = DateTime.Now,
        //                UpdatedAt = DateTime.Now,   
        //            };
        //            tasks.Add(newTask);
        //            repository.SaveAllTasks(tasks);
        //            Console.WriteLine($"Task added successfully (ID: {newId})");
        //            break;

        //        case "list":
        //            var allTasks = repository.GetAllTasks();

        //            if (args.Length >= 2)
        //            {
        //                string statusFilter = args[1].ToLower();
        //                allTasks = allTasks.FindAll(t => t.Status == statusFilter);
        //            }

        //            if (allTasks.Count == 0)
        //            {
        //                Console.WriteLine("No tasks in the list!");
        //                break;
        //            }
        //            Console.WriteLine("------ TASKS LIST ------");
        //            foreach (var task in allTasks)
        //            {
        //                Console.WriteLine($"[{task.Id}] {task.Description} - Status: {task.Status} (Update: {task.UpdatedAt:dd/MM/yyyy HH:mm})");
        //            }

        //            break;
        //        case "update":
        //            if (args.Length < 3)
        //            {
        //                Console.WriteLine("Error: Wrong syntax. Ex: task-cli update 1 \"Have a dinner\"");
        //                break;
        //            }

        //            if (!int.TryParse(args[1], out int updateId))
        //            {
        //                Console.WriteLine("Error: ID must be a number.");
        //                break;
        //            }

        //            var tasksForUpdate = repository.GetAllTasks();

        //            var taskToUpdate = tasksForUpdate.Find(t => t.Id == updateId);

        //            if (taskToUpdate == null)
        //            {
        //                Console.WriteLine($"[Error] Not found the task with ID: {updateId}");
        //                break;
        //            }

        //            taskToUpdate.Description = args[2];
        //            taskToUpdate.UpdatedAt = DateTime.Now;

        //            repository.SaveAllTasks(tasksForUpdate);
        //            Console.WriteLine($"Task (ID: {updateId}) updated successfully.");

        //            break;

        //        case "delete":
        //            if (args.Length < 2 || !int.TryParse(args[1], out int deleteId))
        //            {
        //                Console.WriteLine("[Error] Wrong syntax or ID. Ex: task-cli delete 1");
        //                break;
        //            }

        //            var tasksForDelete = repository.GetAllTasks();

        //            //Xóa những thằng nào có Id trùng với deleteId (Thực ra ID là duy nhất nên chỉ xóa 1)
        //            int removedCount = tasksForDelete.RemoveAll(t => t.Id == deleteId);
        //            if (removedCount > 0)
        //            {
        //                repository.SaveAllTasks(tasksForDelete);
        //                Console.WriteLine($"Task (ID: {deleteId}) deleted successfully.");
        //            }
        //            else
        //            {
        //                Console.WriteLine($"[Error] Not found the task with ID: {deleteId}");
        //            }     
        //            break;

        //        case "mark-in-progress":
        //        case "mark-done":
        //            if (args.Length < 2 || !int.TryParse(args[1], out int markId))
        //            {
        //                Console.WriteLine($"[Error] Wrong syntax or ID. Ex: task-cli {command} 1");
        //                break;
        //            }

        //            var tasksForMark = repository.GetAllTasks();
        //            var taskToMark = tasksForMark.Find(t => t.Id == markId);

        //            if (taskToMark == null)
        //            {
        //                Console.WriteLine($"[Error] Not fount the task with ID: {markId}");
        //                break;
        //            }

        //            taskToMark.Status = command == "mark-done" ? "done" : "in-progress";

        //            taskToMark.UpdatedAt = DateTime.Now;

        //            repository.SaveAllTasks(tasksForMark);
        //            Console.WriteLine($"Task (ID: {markId}) marked as {taskToMark.Status} successfully.");
        //            break;
        //        default:
        //            Console.WriteLine($"[Error]: Command {command} is not supported!");
        //            break;

            
            
        //    }
        //    Console.ReadLine();
        //}
    }
}
