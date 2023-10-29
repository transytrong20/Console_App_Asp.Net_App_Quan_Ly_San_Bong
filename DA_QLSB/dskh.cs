using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;//

namespace QLSBHD
{
    class dskh //DSKH
    {
        List<khachhang> listkh;
        public dskh()
        {
            listkh = new List<khachhang>();
        }
        public void ReadFile(String fileName)
        {
            listkh = new List<khachhang>();
            StreamReader str = new StreamReader(new FileStream(fileName, FileMode.Open));
            String strTmp;
            String[] tmp;
            while (!str.EndOfStream)
            {
                strTmp = str.ReadLine().Trim();
                if (strTmp != "")
                {
                    tmp = strTmp.Split('#');
                    listkh.Add(new khachhang((tmp[0]), (tmp[1]), (tmp[2]), (int.Parse(tmp[3])), (tmp[4])));
                }
            }
            str.Close();
        }
        public void WriteFile(String fileName)
        {
            StreamWriter str = new StreamWriter(fileName, false);
            foreach (khachhang kh in listkh)
                str.WriteLine(kh.toString());
            str.Close();
        }
        public void Themmoi(String fileName)
        {
            Console.WriteLine("                  ********THEM THONG TIN KHACH HANG!!!*********");
            int chon;
            khachhang kh = new khachhang();

            while (true)
            {
                Console.Write("Nhấn enter hoặc số 0 để kết thúc, nhập số bất kỳ để tiếp tục:");
                chon = int.Parse("0" + Console.ReadLine());
                if (chon == 0)
                    kh.nhap();
                listkh.Add(kh);
                StreamWriter str = new StreamWriter(new FileStream(fileName,
                    FileMode.Append));
                str.WriteLine(kh.toString());
                str.Close();

                Console.WriteLine("Thêm thông tin thành công!!!");
                Console.WriteLine("F9: Thoát ");
                Console.WriteLine("Nhập phím bất kỳ để quay lại menu");
                Console.Write("   Mời bạn nhập phím chức năng: ");

                ConsoleKeyInfo kt1 = Console.ReadKey();

                switch (kt1.Key)
                {
                    case ConsoleKey.F9:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.Clear();
                        MenuKH KH = new MenuKH();

                        KH.Menukh(); break;
                }
            }
        }
        public void ThemMoi(String fileName)
        {
            Console.WriteLine("*******THÊM THÔNG TIN KHÁCH HÀNG!!!********");
            int chon;
            khachhang kh = new khachhang();

            while (true)
            {
                Console.Write("Nhấn enter hoặc số 0 để kểt thúc, nhập số bất kỳ để tiếp tục");
                chon = int.Parse("0" + Console.ReadLine());
                if (chon == 0) break;
                kh.nhap();
                listkh.Add(kh);
                StreamWriter str = new StreamWriter(new FileStream(fileName,
                    FileMode.Append));
                str.WriteLine(kh.toString());
                str.Close();
            }
            Console.WriteLine("Thêm thông tin thành công!!!");
            Console.WriteLine("F9: Thoát ");
            Console.WriteLine("Nhập phím bất kỳ để quay lại menu");
            Console.Write("   Mời bạn nhập phím chức năng: ");
            ConsoleKeyInfo kt = Console.ReadKey();
            switch (kt.Key)
            {
                case ConsoleKey.F9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    MenuKH KH = new MenuKH();
                    KH.Menukh(); break;
            }
        }
        public void HienThiten(String tenKH)
        {
            int stt = 1;
            foreach (khachhang kh in listkh)
                if (kh.Hoten.ToLower().EndsWith(" " + tenKH.ToLower()) ||
                    kh.Hoten.ToLower().CompareTo(tenKH.ToLower()) == 0)
                {
                    Console.Write("{0,-5}", stt);
                    kh.hien();
                    stt++;
                }
        }
        public void hiendskh()
        {
            int stt = 1;
            foreach (khachhang kh in listkh)
            {
                Console.Write("{0,-3}", stt);
                kh.hien();
                stt++;
            }
            Console.WriteLine(" Hiện thị thông tin thành công!!!");
            Console.WriteLine("F9: Thoát ");
            Console.WriteLine("Nhập phím bất kỳ để quay lại menu");
            Console.Write("   Mời bạn nhập phím chức năng: ");
            ConsoleKeyInfo kt = Console.ReadKey();
            switch (kt.Key)
            {
                case ConsoleKey.F9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    MenuKH KH = new MenuKH();
                    KH.Menukh(); break;
            }
        }
        public void xoa(string ma)
        {
            int i = 0;
            foreach (khachhang kh in listkh)
            {
                if (ma == kh.Makh)
                {
                    listkh.RemoveAt(i);
                    break;
                }
                i++;
            }
        }
        public void getkhachhang(string ma)
        {
            foreach (khachhang kh in listkh)
            {
                if (ma.CompareTo(kh.Makh) == 0)
                {
                    kh.hien();
                }
            }
            Console.WriteLine("Tìm kiếm thông tin thành công!!!");
            Console.WriteLine("F9: Thoát ");
            Console.WriteLine("Nhập phím bất kỳ để quay lại menu");
            Console.Write("   Mời bạn nhập phím chức năng: ");
            ConsoleKeyInfo kt = Console.ReadKey();
            switch (kt.Key)
            {
                case ConsoleKey.F9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    MenuKH KH = new MenuKH();
                    KH.Menukh(); break;
            }
        }
        public void truyxuatkh()
        {
            string ma;
            do
            {
                Console.Write("Nhập mã khách hàng muốn truy xuất thông tin:");
                ma = Console.ReadLine();
                if (ktm(ma) == false)
                {
                    Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại!!!");
                }
            }
            while (ktm(ma) == false);
            foreach (khachhang kh in listkh)
            {
                if (ma.CompareTo(kh.Makh) == 0)
                    kh.hien();
            }
        }
        public void capnhat(string makh)
        {
            Console.WriteLine("                  ********SỦA THÔNG TIN KHÁCH HÀNG!!!*********");
            foreach (khachhang kh in listkh)
            {
                if (makh.CompareTo(kh.Makh) == 0)
                {
                    kh.Capnhatkh();
                }
            }
        }
        public khachhang TimkiemTheoMa(string MaKH)
        {
            for (int i = 0; i < listkh.Count; i++)
                if (listkh[i].Makh.CompareTo(MaKH) == 0)
                {
                    return listkh[i];
                }
            return null;
        }
        public bool ktraten(string ten)
        {
            bool kt = false;
            foreach (khachhang kh in listkh)
            {
                if (kh.Hoten.ToLower().EndsWith(" " + ten.ToLower()) ||
                    kh.Hoten.ToLower().CompareTo(ten.ToLower()) == 0)
                {
                    kt = true;
                }
            }
            return kt;
        }
        public bool ktm(string ma)
        {
            bool kt = false;
            foreach (khachhang kh in listkh)
            {
                if (kh.Makh == ma)
                {
                    kt = true;
                }
            }
            return kt;
        }
    }
}