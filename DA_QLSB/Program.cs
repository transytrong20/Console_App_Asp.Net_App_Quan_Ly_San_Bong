using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QLSBHD
{
    static class Program
    {
        static void Main() //main
        {
            Console.OutputEncoding = Encoding.UTF8;
            MenuSB SB = new MenuSB();
            MenuDV DV = new MenuDV();
            MenuKH KH = new MenuKH();
            MenuHD HD = new MenuHD();
            Console.Title = "\t                         cHƯƠNG TRÌNH QUẢN LÝ SÂN BÓNG ";
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("      ||                                     CHƯƠNG TRÌNH QUẢN LÝ SÂN BÓNG                            ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||  F1: Quản lý sân bóng                                      F2: Quản lý dịch vụ               ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||  F3: Quản lý khách hàng                                    F4: Quản lý hóa đơn               ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||  F5: Quay lại                                              F6: Thoát                         ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("Mời nhập để thực hiện");
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        SB.Menusb();
                        break;
                    case ConsoleKey.F2:
                        DV.Menudv();
                        break;
                    case ConsoleKey.F3:
                        KH.Menukh();
                        break;
                    case ConsoleKey.F4:
                        HD.Menuhd();
                        break;
                    case ConsoleKey.F5:
                        stop = true;
                        break;
                    case ConsoleKey.F6:
                        Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}

