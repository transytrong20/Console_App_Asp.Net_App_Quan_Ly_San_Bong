using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class MenuHD //HD
    {
        public void Menuhd()
        {
            Console.Title = "\t                        QUẢN LÝ HOÁ ĐƠN ";
            bool stop = false;
            while (!stop)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.OutputEncoding = Encoding.UTF8;
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                           CHƯƠNG TRÌNH QUẢN LÝ HÓA ĐƠN                                       ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F1: Thêm một hóa đơn                                          ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F2: Doanh thu ngày                                            ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F3: Doanh thu tháng                                           ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F4: Xóa hóa đơn                                               ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F8: Hiện danh sách hóa đơn                                    ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F9: Tìm kiếm hóa đơn theo mã                                  ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F5: Quay lại                                                  ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||                                F6: Thoát                                                     ||");
                Console.WriteLine("      ||                                                                                              ||");
                Console.WriteLine("      ||==============================================================================================||");
                Console.WriteLine();
                Console.WriteLine("Mời nhập để thực hiện:");
                ConsoleKeyInfo kt = Console.ReadKey();
                Console.Clear();
                dshd ds = new dshd();
                string filename = "hoadon.txt";
                switch (kt.Key)
                {
                    case ConsoleKey.F1:
                        ds.ReadFile(filename);
                        ds.ThemMoi(filename);
                        ds.hien();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F2:
                        bool validate; int ngay, thang, nam;
                        Console.WriteLine("Nhập ngày/tháng/năm muốn tìm kiếm:");
                        do
                        {
                            Console.Write("Nhập ngày:");
                            validate = int.TryParse("0" + Console.ReadLine(), out ngay);
                        } while (validate == false || ngay > 31 || ngay < 1);
                        do
                        {
                            Console.Write("Nhập tháng:");
                            validate = int.TryParse("0" + Console.ReadLine(), out thang);
                        } while (validate == false || thang > 12 || thang < 1);
                        do
                        {
                            Console.Write("Nhập năm:");
                            validate = int.TryParse("0" + Console.ReadLine(), out nam);
                        } while (validate == false);
                        ds.ReadFile(filename);
                        Console.Write("Doanh thu ngày:{0}", ds.doanhthungay(ngay, thang, nam));
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F3:
                        bool validated; int thangt, namt;
                        Console.WriteLine("Nhập tháng/năm muốn tìm kiếm:");
                        do
                        {
                            Console.Write("Nhập tháng:");
                            validated = int.TryParse("0" + Console.ReadLine(), out thangt);
                        } while (validated == false || thangt > 12 || thangt < 1);
                        do
                        {
                            Console.Write("Nhập năm:");
                            validate = int.TryParse("0" + Console.ReadLine(), out namt);
                        } while (validate == false);
                        ds.ReadFile(filename);
                        ds.doanhthuthang(thangt, namt);
                        Console.Write("Doanh thu tháng:{0}", ds.doanhthuthang(thangt, namt));
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F4:
                        ds.ReadFile(filename);
                        string ma;
                        Console.WriteLine("*******XOÁ THÔNG TIN HOÁ ĐƠN!!!*******");
                        do
                        {
                            Console.Write("Nhập mã hoá đơn muốn xoá:");
                            ma = Console.ReadLine();
                            if (ds.ktm(ma) == false)
                            {
                                Console.WriteLine("Mã hoá đơn không tồn tại, Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (ds.ktm(ma) == false);
                        ds.xoa(ma);
                        ds.hien();
                        ds.WriteFile(filename);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F10:
                        ds.ReadFile(filename);
                        string ma1;
                        Console.WriteLine("*******CẬP NHẬP THÔNG TIN HOÁ ĐƠN!!!*******");
                        do
                        {
                            Console.Write("Nhập mã hoá đơn muốn sửa:");
                            ma1 = Console.ReadLine();
                            if (ds.ktm(ma1) == false)
                            {
                                Console.WriteLine("Mã hoá đơn không tồn tại, Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (ds.ktm(ma1) == false);
                        ds.CapNhathd(ma1);
                        ds.WriteFile(filename);
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F8:
                        ds.ReadFile(filename);
                        ds.hien();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.F9:
                        ds.ReadFile(filename);
                        string mahd;
                        Console.WriteLine("*******TÌM THÔNG TIN HOÁ ĐƠN!!!*******");
                        do
                        {
                            Console.Write("Nhập mã hoá đơn muốn tìm:");
                            mahd = Console.ReadLine();

                            if (ds.ktm(mahd) == false)
                            {
                                Console.WriteLine("Mã hoá đơn không tồn tại, Vui lòng kiểm tra lại!!!");
                            }
                        }
                        while (ds.ktm(mahd) == false);
                        ds.TimkiemTheoMa(mahd);
                        ds.WriteFile(filename);
                        Console.ReadKey();
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
