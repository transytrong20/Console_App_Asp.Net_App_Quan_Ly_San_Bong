
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace QLSBHD
{
    class hoadon //HD
    {
        private string ngaynhap;
        private string mahoadon;
        private khachhang kh;
        private sanbong sb;
        private dsdv listdv;
        private double t;
        public double T()
        {
            return listdv.thanhtien();
        }
        public string Ngaynhap
        {
            get { return ngaynhap; }
            set { ngaynhap = value; }
        }
        public string Mahoadon
        {
            get { return mahoadon; }
            set
            {
                if (value != "")
                    mahoadon = value;
            }
        }
        public khachhang KH
        {
            get { return kh; }
            set
            {
                if (value != null)
                    kh = value;
            }
        }
        public sanbong SB
        {
            get { return sb; }
            set
            {
                if (value != null)
                    sb = value;
            }
        }
        public hoadon(hoadon hd)
        {
            this.ngaynhap = hd.ngaynhap;
            this.mahoadon = hd.mahoadon;
            this.kh = hd.kh;
            this.sb = hd.sb;
            this.listdv = hd.listdv;
            this.t = hd.t;
        }
        public hoadon(string ngaynhap, string mahoadon, string masanbong, string makh, double tien, dsdv listdv)
        {
            string filename = "khachhang.txt";
            string filenamesb = "sanbong.txt";
            dskh dskhachhang = new dskh();
            dskhachhang.ReadFile(filename);
            kh = dskhachhang.TimkiemTheoMa(makh);
            dssanbong dssanbong = new dssanbong();
            dssanbong.ReadFile(filenamesb);
            sb = dssanbong.TimkiemTheoMa(masanbong);
            this.Ngaynhap = ngaynhap;
            this.mahoadon = mahoadon;
            this.listdv = listdv;
            this.t = tien;
        }
        public hoadon()
        {
            this.ngaynhap = "";
            this.mahoadon = "";
            this.kh = new khachhang();
            this.sb = new sanbong();
            this.listdv = new dsdv();
            this.t = 0;
        }

        public void nhap()
        {
            string MaKH, Madv, masb;
            int SL;
            string filename = "khachhang.txt";
            string filenamesb = "sanbong.txt";
            string filenamedv = "dichvu.txt";
            dshd dshoadon = new dshd();
            dichvu dv = new dichvu();
            dskh listKH = new dskh();
            KH = new khachhang();
            listKH.ReadFile(filename);
            sb = new sanbong();
            dssanbong listbb = new dssanbong();
            listbb.ReadFile(filenamesb);
            dsdv listdv1 = new dsdv();
            listdv1.ReadFile(filenamedv);
            do
            {
                Console.Write("\nNhập mã khách hàng:");
                MaKH = Console.ReadLine();
                if (listKH.ktm(MaKH) == false)
                {
                    Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại:");
                }
            }
            while (listKH.ktm(MaKH) == false);
            KH = listKH.TimkiemTheoMa(MaKH);
            do
            {
                Console.Write("\nNhập mã sân bóng:");
                masb = Console.ReadLine();
                if (listbb.ktm(masb) == false)
                {
                    Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại:");
                }
            }
            while (listbb.ktm(masb) == false);
            sb = listbb.TimkiemTheoMa(masb);
            Console.Write("Ngày bán hàng: ");
            ngaynhap = Console.ReadLine();
            while (true)
            {
            diemdung:
                do
                {
                    Console.Write("\nNhập mã dịch vụ:");
                    Madv = Console.ReadLine();
                    if (Madv == "") break;
                    else
                    {
                        dv = listdv1.TimkiemTheoMa(Madv);
                    }
                    if (dv == null)
                    {
                        Console.WriteLine("Mã dịch vụ không tồn tại. Vui lòng kiểm tra lại:");
                        goto diemdung;
                    }
                    else
                    {
                        Console.Write("Nhập số lượng: ");
                        SL = int.Parse(Console.ReadLine());
                        dv.Soluong1 = SL;
                        Console.WriteLine("{0,-10} {1,-10}{2,-10} {3,-10}", "Tên SP", "Số lượng", "Đơn giá bán", "Thành tiền");
                        Console.WriteLine("{0,-10} {1,-10}{2,-10}{3,-10}", dv.Tendv, dv.Soluong1 = SL, dv.Dongia, dv.tinhtien());
                        listdv.ThemMoi1(dv);
                    }

                } while (dv == null);
                Console.Write("Bạn có muốn nhập thêm không (có nhập (c)): ");
                string s = Console.ReadLine();
                if (s.ToUpper() != "C")
                    break;
            }
        }

        public String toString()
        {
            string str = mahoadon + "#" + kh.Makh + "#" + sb.Masan + "#" + Ngaynhap + "#" + listdv.Count() + "#" + T() + "\r\n" +
                listdv.toString();
            return str.Trim();
        }
        public void Hien()
        {
            Console.WriteLine("                          HOA DON SAN BONG!!!           ");
            try
            {
                Console.WriteLine();
                Console.WriteLine("{0,-5} {1,-5} {2,-10} {3,-10}", mahoadon, kh.Makh, sb.Masan, ngaynhap);
            }
            catch (Exception ex)
            { Console.WriteLine(ex.Message); }
            Console.WriteLine("Thông tin khách hàng:");
            {
                KH.hien();
            }
            Console.WriteLine();
            Console.WriteLine("Dịch vụ đã sử dụng:");
            listdv.hiendsdvhd();
        }
        public void capnhat()
        {
            string MaKH, Madv, masb, ngaynhap;
            string filename = "khachhang.txt";
            string filenamesb = "sanbong.txt";
            string filenamedv = "dichvu.txt";
            dshd dshoadon = new dshd();
            dichvu dv = new dichvu();
            dskh listKH = new dskh();
            KH = new khachhang();
            listKH.ReadFile(filename);
            sb = new sanbong();
            dssanbong listbb = new dssanbong();
            listbb.ReadFile(filenamesb);
            dsdv listdv1 = new dsdv();
            listdv1.ReadFile(filenamedv);
            Console.WriteLine("CẬP NHẬP THÔNG TIN HOÁ ĐƠN");
            Console.Write("Nhập ngày giờ hoặc ấn enter để bỏ qua):");
            ngaynhap = Console.ReadLine().Trim();
            if (ngaynhap.Trim().Length != 0) this.ngaynhap = ngaynhap;
            do
            {
                Console.Write("\nNhập mã khách hàng:");
                MaKH = Console.ReadLine();
                if (listKH.ktm(MaKH) == false)
                {
                    Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại:");
                }
            }
            while (listKH.ktm(MaKH) == false);
            listKH.capnhat(MaKH);
            do
            {
                Console.Write("\nNhập mã sân bóng:");
                masb = Console.ReadLine();
                if (listbb.ktm(masb) == false)
                {
                    Console.WriteLine("Mã sân bóng không tồn tại. Vui lòng kiểm tra lại:");
                }
            }
            while (listbb.ktm(masb) == false);
            listbb.CapNhat(masb);
            do
            {
                Console.Write("\nNhập mã giao dịch:");
                Madv = Console.ReadLine();
                if (listdv1.ktm(Madv) == false)
                {
                    Console.WriteLine("Mã giao dịch không tồn tại. Vui lòng kiểm tra lại:");
                }
            }
            while (listdv1.ktm(masb) == false);
            listdv1.CapNhat(Madv);
        }
    }
}


