using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLSBHD
{
    class dsdv //DV
    {
        List<dichvu> listdv;
        private string filename = "dichvu.txt";
        public dsdv()
        {
            listdv = new List<dichvu>();
        }
        public void ReadFile(String fileName)
        {
            listdv = new List<dichvu>();
            StreamReader str = new StreamReader(new FileStream(fileName, FileMode.Open));
            String strTmp;
            String[] tmp;
            while (!str.EndOfStream)
            {
                strTmp = str.ReadLine().Trim();
                if (strTmp != "")
                {
                    tmp = strTmp.Split('#');
                    listdv.Add(new dichvu((tmp[0]), (tmp[1]), (int.Parse(tmp[2])),
                        (double.Parse(tmp[3]))));
                }
            }
            str.Close();
        }
        public void WriteFile(String fileName)
        {
            StreamWriter str = new StreamWriter(fileName, false);
            foreach (dichvu dv in listdv)
                str.WriteLine(dv.toString());
            str.Close();
        }
        public void ThemMoi(String fileName)
        {
            Console.WriteLine("*******THÊM THÔNG TIN DỊCH VỤ!!!********");
            int chon;
            dichvu dv = new dichvu();
            string ma;

            while (true)
            {
                Console.Write("Nhấn enter hoặc số 0 để kết thúc, nhập số bất kỳ để tiếp tục:");
                chon = int.Parse("0" + Console.ReadLine());
                if (chon == 0) break;
                do
                {
                    Console.Write("Nhập mã dịch vụ:");
                    ma = Console.ReadLine();
                    if (ktm(ma) == true)
                    {
                        Console.WriteLine("Mã dịch vụ không tồn tại. Vui lòng kiểm tra lại:");
                    }
                }
                while (ktm(ma) == true);
                dv.Madv = ma;
                dv.nhapdv();
                listdv.Add(dv);
                StreamWriter str = new StreamWriter(new FileStream(fileName,
                    FileMode.Append));
                str.WriteLine(dv.toString());
                str.Close();
            }
            Console.WriteLine("Thêm dịch vụ thành công!!!");
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
                    MenuSB SB = new MenuSB();
                    SB.Menusb(); break;
            }
        }
        public void ThemMoi1(dichvu dv)
        {
            listdv.Add(dv);
        }
        public void nhap()
        {
            foreach (dichvu dv in listdv)
                dv.nhapdv();
        }
        public void CapNhat(string ma)
        {
            foreach (dichvu dv in listdv)
            {
                if (ma.CompareTo(dv.Madv) == 0)
                {
                    dv.capnhat();
                }
            }
        }
        public double thanhtien()
        {
            double t = 0;
            foreach (dichvu dv in listdv)
                t = t + dv.tinhtien();
            return t;
        }
        public String toString()
        {
            String tmp = "";
            foreach (dichvu dv in listdv)
                tmp = tmp + "\r\n" + dv.toString();
            return tmp.Trim();
        }
        public void hiendsdv()
        {
            int stt = 1;
            Console.WriteLine("{0,-10}{1,-20}{2,-10}{3,-10}{4,-10}{5,-10} ", "STT", "Ma dv", "Ten dv", "Soluong", "don gia", "thanh tien");
            foreach (dichvu dv in listdv)
            {
                Console.Write("{0,-4}", stt);
                dv.hiendv();
                stt++;
            }
            Console.WriteLine("Hiện thông tin thành công!!!");
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
                    MenuDV DV = new MenuDV();
                    DV.Menudv(); break;
            }
        }
        public void xoa(string ma)
        {
            int i = 0;
            foreach (dichvu dv in listdv)
            {
                if (ma == dv.Madv)
                {
                    listdv.RemoveAt(i);
                    break;
                }
                i++;
            }
        }
        public void hiendsdvhd()
        {
            int stt = 1;
            foreach (dichvu dv in listdv)
            {
                Console.Write("{0,-3}", stt);
                dv.hiendv();
                stt++;
            }
            Console.WriteLine("Tong tien: " + thanhtien());
        }
        public int Count()
        {
            int t = 0;
            foreach (dichvu dv in listdv)
            {
                if (dv.Madv != "")
                    t = t + 1;
            }
            return t;
        }
        public bool ktm(string ma)
        {
            bool kt = false;
            foreach (dichvu dv in listdv)
            {
                if (dv.Madv == ma)
                {
                    kt = true;
                }
            }
            return kt;
        }
        public dichvu TimkiemTheoMa(string MaDV)
        {
            for (int i = 0; i < listdv.Count; i++)
                if (listdv[i].Madv.CompareTo(MaDV) == 0)
                {
                    return listdv[i];
                }
            return null;
        }
        public void SapXep()
        {
            ReadFile(filename);
            dichvu dv = new dichvu();
            for (int i = 0; i < listdv.Count - 1; i++)
            {
                for (int j = i + 1; j < listdv.Count; j++)
                {
                    if (listdv[i].Soluong1 < listdv[j].Soluong1)
                    {
                        dv.Soluong1 = listdv[j].Soluong1;
                        listdv[j].Soluong1 = listdv[i].Soluong1;
                        listdv[i].Soluong1 = dv.Soluong1;
                        dv.Madv = listdv[j].Madv;
                        listdv[j].Madv = listdv[i].Madv;
                        listdv[i].Madv = dv.Madv;
                        dv.Tendv = listdv[j].Tendv;
                        listdv[j].Tendv = listdv[i].Tendv;
                        listdv[i].Tendv = dv.Tendv;

                        dv.Dongia = listdv[j].Dongia;
                        listdv[j].Dongia = listdv[i].Dongia;
                        listdv[i].Dongia = dv.Dongia;
                    }
                }
            }
            hiendsdv();
            Console.ReadKey();
        }
    }
}
