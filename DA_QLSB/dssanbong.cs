using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLSBHD
{
    class dssanbong //DSSB
    {
        List<sanbong> listsb;
        public dssanbong()
        {
            listsb = new List<sanbong>();
        }
        public void ReadFile(String fileName)
        {
            listsb = new List<sanbong>();
            StreamReader str = new StreamReader(fileName);
            String tmp;
            sanbong sb;
            while (str.EndOfStream == false)
            {
                tmp = str.ReadLine().Trim();
                if (tmp == "") continue;
                sb = new sanbong(tmp);
                listsb.Add(sb);
            }
            str.Close();
        }
        public void WriteFile(String fileName)
        {
            StreamWriter str = new StreamWriter(fileName);
            foreach (sanbong bb in listsb)
                str.WriteLine(bb.toString());
            str.Close();
        }
        public void ThemMoi(String fileName)
        {
            Console.WriteLine("*******THÊM THÔNG TIN SÂN BÓNG!!!********");
            int chon;
            sanbong sb = new sanbong();
            string ma;

            while (true)
            {
                Console.Write("Nhân enter hoặc số 0 để kết thúc, nhập số bất kỳ để tiếp tục:");
                chon = int.Parse("0" + Console.ReadLine());
                if (chon == 0) break;
                do
                {
                    Console.Write("Nhập mã sân bóng:");
                    ma = Console.ReadLine();
                    if (ktm(ma) == true)
                    {
                        Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại:");
                    }
                }
                while (ktm(ma) == true);
                sb.Masan = ma;
                sb.nhap();
                listsb.Add(sb);
                StreamWriter str = new StreamWriter(new FileStream(fileName,
                    FileMode.Append));
                str.WriteLine(sb.toString());
                str.Close();
            }
            Console.WriteLine("Thêm sân bóng thành công.");
            Console.WriteLine("F9: Thoát chương trìn!!! ");
            Console.WriteLine("Nhập phím bất kỳ để quay lại menu");
            Console.Write("    Mời bạn nhập phím chức năng: ");
            ConsoleKeyInfo kt = Console.ReadKey();
            switch (kt.Key)
            {
                case ConsoleKey.F9:
                    Environment.Exit(0);
                    break;
                default:
                    Console.Clear();
                    MenuSB SB = new MenuSB();
                    SB.Menusb(); break;
            }
        }
        public void hiendsb()
        {
            int stt = 1;
            foreach (sanbong sb in listsb)
            {
                Console.Write("{0,-4}", stt);
                sb.hien();
                stt++;
            }
            Console.WriteLine(" Hiện thông tin thành công!!!");
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
                    MenuSB BB = new MenuSB();
                    BB.Menusb(); break;
            }
        }
        public void timkiemsucchua(int succhua)
        {
            foreach (sanbong bb in listsb)
            {
                if (bb.Succhua == succhua)
                {
                    bb.hien();
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
                    MenuSB BB = new MenuSB();
                    BB.Menusb(); break;
            }
        }
        // dùng vòng lặp for để duyệt tìm kiếm
        public sanbong TimkiemTheoMa(string Mabb)
        {
            for (int i = 0; i < listsb.Count; i++)
                if (listsb[i].Masan.CompareTo(Mabb) == 0)
                {
                    return listsb[i];
                }
            return null;
        }
        // dùng câu lệnh foreach để duyệt từ đầu tới cuối danh sách xem có mã nào trùng thì sửa
        public void CapNhat(string ma)
        {
            foreach (sanbong bb in listsb)
            {
                if (ma.CompareTo(bb.Masan) == 0)
                {
                    bb.capnhatsucchua();
                }
            }
        }
        //dùng vòng lặp foreach để duyệt xem có mã nào trùng thì xóa 
        public void xoa(string ma)
        {
            int i = 0;
            foreach (sanbong bb in listsb)
            {
                if (ma == bb.Masan)
                {
                    listsb.RemoveAt(i);
                    break;
                }
                i++;
            }
        }
        public void getsanbong(string ma)
        {
            foreach (sanbong bb in listsb)
            {
                if (ma.CompareTo(bb.Masan) == 0)
                {
                    bb.hien();
                }
            }
        }
        public bool ktm(string ma)
        {
            bool kt = false;
            foreach (sanbong bb in listsb)
            {
                if (bb.Masan == ma)
                {
                    kt = true;
                }
            }
            return kt;
        }
        public bool ktSc(int succhua)
        {
            bool kt = false;
            foreach (sanbong bb in listsb)
            {
                if (bb.Succhua == succhua)
                {
                    kt = true;
                }
            }
            return kt;
        }
    }
}