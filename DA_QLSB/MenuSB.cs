
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class MenuSB //sb
    {
        public void Menusb()
        {
            Console.Title = "\t                        QUẢN LÝ SÂN BÓNG ";
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                           CHƯƠNG TRÌNH QUẢN LÝ SÂN BÓNG                                      ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F1: Thêm một sân bóng                                             ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F2: Cập nhật lại sức chứa                                         ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F3: Hiển thị danh sách sân bóng                                   ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F4: Tìm kiếm theo mã                                              ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F5: Xóa thông tin sân                                             ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F6: Tìm kiếm theo sức chứa                                        ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F8: Quay lại                                                      ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                            F9: Thoát                                                         ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine();
                Console.WriteLine("mời nhập để thực hiện:");
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                dssanbong ds = new dssanbong();
                string filename = "sanbong.txt";
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        ds.ReadFile(filename);
                        ds.ThemMoi(filename);
                        break;
                    case ConsoleKey.F2:
                        ds.ReadFile(filename);
                        string ma;
                        Console.WriteLine("*******SỬA CHỮA SÂN BÓNG!!!*******");
                        do
                        {
                            Console.Write("Nhập mã sân bóng muốn sửa:");
                            ma = Console.ReadLine();
                            if (ds.ktm(ma) == false)
                            {
                                Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại mã!!!");
                            }
                        }
                        while (ds.ktm(ma) == false);
                        ds.CapNhat(ma);
                        ds.WriteFile(filename);
                        ds.hiendsb();
                        break;
                    case ConsoleKey.F3:
                        ds.ReadFile(filename);
                        ds.hiendsb();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        ds.ReadFile(filename);
                        string ma1;
                        Console.WriteLine("*******TÌM SÂN BÓNG!!!*******");
                        do
                        {
                            Console.Write("Nhập mã sân muốn tìm:");
                            ma1 = Console.ReadLine();

                            if (ds.ktm(ma1) == false)
                            {
                                Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại mã!!!");
                            }
                        }
                        while (ds.ktm(ma1) == false);
                        ds.getsanbong(ma1);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        ds.ReadFile(filename);
                        int succhua;
                        Console.WriteLine("*******TÌM THÔNG TIN SÂN BÓNG!!!*******");
                        do
                        {
                            Console.Write("Nhập sức chứa muốn tìm:");
                            succhua = int.Parse(Console.ReadLine());

                            if (ds.ktSc(succhua) == false)
                            {
                                Console.WriteLine("Không có sân bóng với sức chứa bạn tìm. Vui lòng kiểm tra lại sức chứa!!!");
                            }
                        }
                        while (ds.ktSc(succhua) == false);
                        ds.timkiemsucchua(succhua);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        ds.ReadFile(filename);
                        string ma2;
                        Console.WriteLine("*******XOÁ THÔNG TIN SÂN BÓNG!!!*******");
                        do
                        {
                            Console.Write("Nhập mã sân bóng muốn xoá:");
                            ma2 = Console.ReadLine();

                            if (ds.ktm(ma2) == false)
                            {
                                Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại mã!!!");
                            }
                        }
                        while (ds.ktm(ma2) == false);
                        ds.xoa(ma2);
                        ds.hiendsb();
                        ds.WriteFile(filename);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F8:
                        stop = true;
                        break;
                    case ConsoleKey.F9:
                        Environment.Exit(0); break;
                    default:
                        break;
                }
            }
        }
    }
}

