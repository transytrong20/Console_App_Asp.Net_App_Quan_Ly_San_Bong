using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class MenuDV //DV
    {
        public void Menudv()
        {
            Console.Title = "\t                        QUẢN LÝ DỊCH VỤ ";
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("      ||                         CHƯƠNG TRÌNH QUẢN LÝ DỊCH VỤ SÂN BÓNG                                ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F1: Thêm một dịch vụ                                           ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F2: Cập nhật dịch vụ                                           ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F3: Hiện danh sách dịch vụ                                     ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F4: Xóa dịch vụ                                                ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F5: Sắp xếp                                                    ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F8: Quay lại                                                   ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                               F9: Thoát                                                      ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine();
                Console.WriteLine("Mời nhập để thực hiện:");
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                dsdv ds = new dsdv();
                string filename = "dichvu.txt";
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        ds.ReadFile(filename);
                        ds.ThemMoi(filename);
                        break;
                    case ConsoleKey.F2:
                        ds.ReadFile(filename);
                        string ma;
                        Console.WriteLine("*******SỦA THÔNG TIN DỊCH VỤ!!!*******");
                        do
                        {
                            Console.Write("Nhập mã dịch vụ muốn sửa:");
                            ma = Console.ReadLine();

                            if (ds.ktm(ma) == false)
                            {
                                Console.WriteLine("Mã dịch vụ không tồn tại. Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (ds.ktm(ma) == false);
                        ds.CapNhat(ma);
                        ds.WriteFile(filename);
                        ds.hiendsdv();
                        break;
                    case ConsoleKey.F3:
                        ds.ReadFile(filename);
                        ds.hiendsdv();
                        break;
                    case ConsoleKey.F4:
                        ds.ReadFile(filename);
                        string ma2;
                        Console.WriteLine("*******XOÁ THÔNG TIN DỊCH VỤ!!!*******");
                        do
                        {
                            Console.Write("Nhập mã dịch vụ muốn xoá:");
                            ma2 = Console.ReadLine();

                            if (ds.ktm(ma2) == false)
                            {
                                Console.WriteLine("Mã dịch vụ không tồn tại. Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (ds.ktm(ma2) == false);
                        ds.xoa(ma2);
                        ds.hiendsdv();
                        ds.WriteFile(filename);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        ds.SapXep();
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