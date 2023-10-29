using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class khachhang //KH
    {
        private string makh;
        private string hoten;
        private string ngaygiodatlich;
        private int soluong;
        private string sdt;
        public string Hoten
        {
            get { return hoten; }
            set
            {
                if (value != "")
                    hoten = value;
            }
        }
        public string Makh
        {
            get { return makh; }
            set
            {
                if (value != "")
                    makh = value;
            }
        }
        public string Ngaygio
        {
            get { return ngaygiodatlich; }
            set
            {
                ngaygiodatlich = value;
            }
        }
        public int Soluong
        {
            get { return soluong; }
            set { soluong = value; }
        }
        public string Sdt
        {
            get { return sdt; }
            set { sdt = value; }
        }
        public khachhang()
        {
            makh = "";
            hoten = "";
            ngaygiodatlich = "";
            soluong = 0;
            sdt = "";
        }
        public khachhang(khachhang obj)
        {
            this.makh = obj.makh;
            this.hoten = obj.hoten;
            this.ngaygiodatlich = obj.ngaygiodatlich;
            this.soluong = obj.soluong;
            this.sdt = obj.sdt;
        }
        public khachhang(string makh, string hoten, string ngaygio, int soluong, string sdt)
        {
            this.makh = makh;
            this.hoten = hoten;
            this.ngaygiodatlich = ngaygio;
            this.soluong = soluong;
            this.sdt = sdt;
        }
        public void nhap()
        {
            dskh ds = new dskh();
            do
            {
                Console.Write("Nhập mã khách hàng:");
                makh = Console.ReadLine();
                if (ds.ktm(makh) == true)
                {
                    Console.WriteLine("Mã khách hàng không tồn tại. Vui lòng kiểm tra lại :");
                }
            }
            while (ds.ktm(makh) == true);
            do
            {
                Console.Write("Nhập họ tên:"); hoten = Console.ReadLine();

            } while (hoten == "");
            do
            {
                Console.Write("Nhập ngày giờ:"); ngaygiodatlich = Console.ReadLine();

            } while (ngaygiodatlich == "");
            do
            {
                Console.Write("Nhập số lượng người:");
                soluong = int.Parse(Console.ReadLine());
            } while (soluong <= 0);
            do
            {
                Console.Write("Nhập số điện thoại:");
                sdt = Console.ReadLine();
            } while (sdt == "");
        }
        public void Capnhatkh()
        {
            string hoten, ngaygio, sodt; int soluong = 0; bool validate;
            Console.Write("Nhập họ tên khách hàng hoặc ấn enter để bỏ qua):");
            hoten = Console.ReadLine().Trim();
            if (hoten.Trim().Length != 0) this.hoten = hoten;
            Console.Write("Nhập ngày, giờ hoặc ấn enter để bỏ qua):");
            ngaygio = Console.ReadLine().Trim();
            if (ngaygio.Trim().Length != 0) this.ngaygiodatlich = ngaygio;
            Console.Write("Nhập số điện thoại hoặc ấn enter để bỏ qua):");
            sodt = Console.ReadLine().Trim();
            if (sodt.Trim().Length != 0) this.sdt = sodt;
            do
            {
                Console.Write("Nhập số lượng người hoặc ấn enter để bỏ qua");
                validate = int.TryParse("0" + Console.ReadLine(), out soluong);
            } while (validate == false);
            if (soluong != 0) this.soluong = soluong;
        }
        public String toString()
        {
            return makh + "#" + hoten + "#" + ngaygiodatlich + "#" + soluong + "#" + Sdt;
        }

        public void hien()
        {
            Console.WriteLine("{0,-10}{1,-20}{2,-15}{3,-9}{4,-9}", makh, hoten, sdt, soluong, ngaygiodatlich);
        }
    }
}


