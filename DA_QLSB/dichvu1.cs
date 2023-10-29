using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class dichvu //DV
    {
        private string madv;
        private string tendv;
        private int soluong1;
        private double dongia;
        public string Madv
        {
            get { return madv; }
            set
            {
                if (value != "")
                    madv = value;
            }
        }
        public string Tendv
        {
            get { return tendv; }
            set
            {
                if (value != "")
                    tendv = value;
            }
        }
        public int Soluong1
        {
            get { return soluong1; }
            set
            {
                if (value > 0)
                    soluong1 = value;
            }
        }
        public double Dongia
        {
            get { return dongia; }
            set
            {
                if (value > 0)
                    dongia = value;
            }
        }
        public dichvu()
        {
            madv = "";
            tendv = "";
            soluong1 = 0;
            dongia = 0;
        }
        public dichvu(string madv, string tendv, int soluong1, double dongia)
        {
            this.madv = madv;
            this.tendv = tendv;
            this.dongia = dongia;
            this.soluong1 = soluong1;
        }
        public dichvu(dichvu obj)
        {
            this.madv = obj.madv;
            this.tendv = obj.tendv;
            this.dongia = obj.dongia;
            this.soluong1 = obj.soluong1;
        }
        public double tinhtien()
        {
            return dongia * soluong1;
        }
        public void nhapdv()
        {

            do
            {
                Console.Write("Nhập tên dịch vụ:"); tendv = Console.ReadLine();
            } while (tendv == "");
            do
            {
                Console.Write("Nhập số lượng:"); soluong1 = int.Parse(Console.ReadLine());
            } while (soluong1 <= 0);
            do
            {
                Console.Write("Nhập đơn giá:"); dongia = double.Parse(Console.ReadLine());
            } while (dongia <= 0);
        }
        public String toString()
        {
            return madv + "#" + tendv + "#" + soluong1 + "#" + dongia;
        }
        public void hiendv()
        {
            Console.WriteLine("{0,10}{1,20}{2,10}{3,10}{4,10}", madv, tendv, soluong1, dongia, tinhtien());
            Console.WriteLine();
        }
        public void capnhat()
        {
            string tendv;
            bool validate;
            int soluong = 0;
            double dongia = 0;
            Console.WriteLine("  Nhấn enter để giữ nguyên dịch vụ:");
            do
            {
                Console.Write(" Nhập tên dịch vụ mới hoặc nhấn enter để giữ nguyên:");
                tendv = Console.ReadLine().Trim();
            } while (tendv.Trim().Length < 0);
            if (tendv.Trim().Length != 0) this.Tendv = tendv;
            do
            {
                Console.Write(" Nhập số lương mới hoặc nhấn enter để giữ nguyên:");
                validate = int.TryParse("0" + Console.ReadLine(), out soluong);
            } while (validate == false);
            if (soluong != 0)
                this.soluong1 = soluong;
            do
            {
                Console.Write(" Nhập đơn giá mới hoặc nhấn enter để giữ nguyên:");
                validate = double.TryParse("0" + Console.ReadLine(), out dongia);
            } while (validate == false);
            if (dongia != 0)
                this.dongia = dongia;
        }
    }
}
