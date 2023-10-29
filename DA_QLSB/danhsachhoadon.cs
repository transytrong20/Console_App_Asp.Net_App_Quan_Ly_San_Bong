using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLSBHD
{
    class dshd //DSHD
    {
        private List<hoadon> listhd;
        public dshd()
        {
            listhd = new List<hoadon>();
        }
        public void nhap()
        {
            foreach (hoadon hd in listhd)
                hd.nhap();
        }
        public void hien()
        {
            int stt = 1;
            foreach (hoadon hdb in listhd)
            {
                Console.Write("{0,-5}", stt);
                hdb.Hien();
                stt++;
            }
        }
        public void ReadFile(string filename)
        {
            listhd = new List<hoadon>();
            StreamReader str = new StreamReader(new FileStream(filename, FileMode.Open));
            String strTmp;
            String[] tmp, tmp1;
            string sl = "";
            hoadon hdb = new hoadon();
            dsdv ds;
            while (!str.EndOfStream)
            {
                strTmp = str.ReadLine().Trim();
                if (strTmp == "") continue;
                tmp1 = strTmp.Split('#');
                ds = new dsdv();
                for (int i = 0; i < int.Parse(tmp1[tmp1.Length - 2]); i++)
                {
                    sl = str.ReadLine() ?? "";
                    if (sl == "") continue;
                    tmp = sl.Split('#');
                    try
                    {
                        ds.ThemMoi1(new dichvu(tmp[0], tmp[1], int.Parse(tmp[2]), double.Parse(tmp[3])));
                    }
                    catch (Exception ex)
                    { Console.WriteLine(ex.Message); }
                }
                hdb = new hoadon(tmp1[3], tmp1[0], tmp1[2], tmp1[1], double.Parse(tmp1[5]), ds);
                listhd.Add(hdb);
            }
            str.Close();
        }
        public void WriteFile(String fileName)
        {
            StreamWriter str = new StreamWriter(fileName, false);
            foreach (hoadon hd in listhd)
                str.WriteLine(hd.toString());
            str.Close();
        }
        //them thong tin
        public void ThemMoi(String fileName)
        {
            Console.WriteLine("*******THÊM THÔNG TIN HOÁ ĐƠN!!!********");
            int chon;
            hoadon HD = new hoadon();
            string ma;

            while (true)
            {
                Console.Write(" Nhấn enter hoặc số không để kết thúc, nhập số bất kỳ để tiếp tục:");
                chon = int.Parse("0" + Console.ReadLine());
                if (chon == 0) break;
                do
                {
                    Console.Write("Nhập mã hoá đơn:");
                    ma = Console.ReadLine();
                    if (ktm(ma) == true)
                    {
                        Console.WriteLine("Mã hoá đơn không tồn tại. Vui lòng kiểm tra lại:");
                    }
                }
                while (ktm(ma) == true);
                HD.Mahoadon = ma;
                HD.nhap();
                listhd.Add(HD);
                StreamWriter str = new StreamWriter(new FileStream(fileName,
                    FileMode.Append));
                str.WriteLine(HD.toString());
                str.Close();
            }
            Console.WriteLine("Thêm hoá đơn thành công!!!");
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
                    MenuHD hd = new MenuHD();
                    hd.Menuhd(); break;
            }
        }
        public bool ktm(string ma)
        {
            bool kt = false;
            foreach (hoadon hd in listhd)
            {
                if (hd.Mahoadon == ma)
                {
                    kt = true; 
                }
            }
            return kt;
        }
        public void CapNhathd(string ma)
        {
            foreach (hoadon hd in listhd)
            {
                if (ma.CompareTo(hd.Mahoadon) == 0)
                {
                    hd.capnhat();
                }
            }
        }
        public void xoa(string ma)
        {
            int i = 0;
            foreach (hoadon hd in listhd)
            {
                if (ma == hd.Mahoadon)
                {
                    listhd.RemoveAt(i);
                    break;
                }
                i++;
            }

        }
        public double doanhthungay(int ngay, int thang, int nam)
        {
            double dtn = 0;
            string tn = ngay + "/" + thang + "/" + nam;
            foreach (hoadon hd in listhd)
            {
                if (hd.Ngaynhap.Contains(tn))
                    dtn = dtn + hd.T();
            }
            return dtn;
        }
        public double doanhthuthang(int thang, int nam)
        {
            double dtt = 0;
            string tn = "/" + thang + "/" + nam;
            foreach (hoadon hd in listhd)
            {
                if (hd.Ngaynhap.Contains(tn))
                    dtt = dtt + hd.T();
            }
            return dtt;
        }
        public void TimkiemTheoMa(string Mahd)
        {
            for (int i = 0; i < listhd.Count; i++)
                if (listhd[i].Mahoadon.CompareTo(Mahd) == 0)
                    listhd[i].Hien();
        }
    }
}