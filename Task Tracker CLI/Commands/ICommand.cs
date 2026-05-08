using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_Tracker_CLI.Commands
{
    //Bất kỳ class nào muốn làm "Lệnh" thì phải ký bản hợp đồng này
    public interface ICommand
    {
        // Hàm Execute sẽ nhận mảng args từ Terminal truyền vào
        void Execute(string[] args);
    }
}
