using System.Text.Json;
using Task_Tracker_CLI.Models;

namespace Task_Tracker_CLI.Repositories
{
    //Dùng 2 hệ thống Native File System: System.IO và System.Text.Json
    public class TaskRepository
    {
        private readonly string _filePath = "tasks.json";

        ///<summary>
        /// Hàm này giúp mở file JSON và biến nó thành 1 List<TaskItem> trong RAM
        /// </summary>
        /// 
        public List<TaskItem> GetAllTasks()
        {
            if(!File.Exists(_filePath))
            {
                return new List<TaskItem>();
            }

            // Đọc toàn bộ text trong file ra thành 1 chuỗi string
            string json = File.ReadAllText(_filePath);

            //Deserialize: Biến chuỗi JSON thành List<TaskItem>
            var tasks = JsonSerializer.Deserialize <List<TaskItem>>(json);

            return tasks ?? new List<TaskItem>();
        }

        /// <summary>
        /// Hàm này giúp cầm cái List<TaskItem> đang có trong RAM và ghi đè xuống file JSON
        /// </summary>
        /// 
        public void SaveAllTasks(List<TaskItem> tasks)
        {
            //Dùng để thụt vào đầu dòng cho dễ đọc
            var options = new JsonSerializerOptions { WriteIndented = true };

            //Serialize: Biến List<TaskItem> thành chuỗi JSON
            string json = JsonSerializer.Serialize(tasks, options);

            //Ghi toàn bộ chuỗi này vào file, tự động tạo ra file nếu chưa có luôn!!!
            File.WriteAllText(_filePath, json);
        }

    }
}
