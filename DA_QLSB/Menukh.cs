using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class MenuKH //KH
    {
        public void Menukh()
        {
            Console.Title = "\t                         QUẢN LÝ KHÁCH HÀNG";
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("      ||                              QUẢN LÝ KHÁCH HÀNG                                              ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F1: Thêm mới khách hàng                                         ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F2: Cập nhật khách hàng                                         ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F3: Tìm kiếm khách hàng theo tên                                ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F4: Tìm kiếm khách hàng theo mã                                 ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F5: Xóa thông tin khách hàng                                    ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F6: Hiển thị danh sách khách hàng                               ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F7: Quay lại                                                    ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                              F8:Thoát                                                        ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine();
                Console.WriteLine("Mời nhập để thực hiện:");
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                dskh kh = new dskh();
                string filename = "khachhang.txt";
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        kh.ReadFile(filename);
                        kh.ThemMoi(filename);
                        break;
                    case ConsoleKey.F2:
                        string makh;
                        kh.ReadFile(filename);
                        do
                        {
                            Console.Write("Nhập mã khách hàng muốn sửa thông tin:");
                            makh = Console.ReadLine();
                            if (kh.ktm(makh) == false)
                                Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại mã:");
                        }
                        while (kh.ktm(makh) == false);
                        Console.Clear();
                        kh.capnhat(makh);
                        kh.WriteFile(filename);
                        kh.hiendskh();
                        break;
                    case ConsoleKey.F3:
                        kh.ReadFile(filename);
                        string ten;
                        Console.WriteLine("*******TÌM THÔNG TIN KHÁCH HÀNG!!!*******");
                        do
                        {
                            Console.Write("Nhập tên khách hàng muốn tìm:");
                            ten = Console.ReadLine();
                            if (kh.ktraten(ten) == false)
                            {
                                Console.WriteLine("Tên khách hàng không tồn tại. Vui lòng kiểm tra lại !!!");
                            }
                        }
                        while (kh.ktraten(ten) == false);
                        kh.HienThiten(ten);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        kh.ReadFile(filename);
                        string ma;
                        Console.WriteLine("*******TÌM THÔNG TIN KHÁCH HÀNG!!!*******");
                        do
                        {
                            Console.Write("Nhập mã khách hàng muốn tìm:");
                            ma = Console.ReadLine();

                            if (kh.ktm(ma) == false)
                            {
                                Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (kh.ktm(ma) == false);
                        kh.getkhachhang(ma);
                        kh.WriteFile(filename);
                        kh.hiendskh();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F5:
                        kh.ReadFile(filename);
                        string ma2;
                        Console.WriteLine("*******XOÁ THÔNG TIN KHÁCH HÀNG!!!*******");
                        do
                        {
                            Console.Write("Nhập mã khách hàng muốn xoá:");
                            ma2 = Console.ReadLine();

                            if (kh.ktm(ma2) == false)
                            {
                                Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (kh.ktm(ma2) == false);
                        kh.xoa(ma2);
                        kh.hiendskh();
                        kh.WriteFile(filename);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F6:
                        kh.ReadFile(filename);
                        kh.hiendskh();
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