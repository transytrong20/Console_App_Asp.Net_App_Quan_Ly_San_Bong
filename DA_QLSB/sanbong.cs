using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSBHD
{
    class sanbong
    {
        private string masan;
        private string tensan;
        private int chieudai, chieurong,succhua;
        public string Masan
        {
            get { return masan; }
            set
            {
                if (value != "")
                    masan = value;
            }
        }
        public string Tensan
        {
            get { return tensan; }
            set
            {
                if (value != "")
                    tensan = value;
            }
        }
        public int Chieudai //s
        {
            get { return chieudai; }
            set
            {
                if (value > 0)
                    chieudai = value;
            }
        }
        public int Chieurong
        {
            get { return chieurong; }
            set
            {
                if (value > 0)
                    chieurong = value;
            }
        }
        public int Succhua
        {
            get { return succhua; }
            set
            {
                if (value > 0)
                    succhua = value;
            }
        }
        public sanbong()
        {
            masan = "";
            tensan = "";
            chieudai = 0;
            chieurong = 0;
            succhua = 0;
        }
        public sanbong(sanbong obj)
        {
            this.masan = obj.masan;
            this.tensan = obj.tensan;
            this.chieudai = obj.chieudai;
            this.Chieurong = obj.chieurong;
            this.succhua = obj.succhua;
        }
        public sanbong(string sb)
        {

            string[] tmp = sb.Split('#');
            this.masan = tmp[0];
            this.tensan = tmp[1]; ;
            this.chieudai = int.Parse(tmp[2]) ;
            this.chieurong = int.Parse(tmp[3]);

        }
        public sanbong(string masan, string tensan, int chieudai, int chieurong, int succhua)
        {
            this.masan = masan;
            this.tensan = tensan;
            this.chieudai = chieudai;
            this.chieurong = chieurong;
            this.succhua = succhua;
        }
        public void nhap()
        {
            do
            {
                Console.Write("Nhập tên sân :");
                tensan = Console.ReadLine();
            } while (tensan == "");
            do
            {
                Console.Write("Chiều dài:");
                chieudai = int.Parse(Console.ReadLine());
            } while (chieudai <= 0);
            do
            {
                Console.Write("Chiều rộng:");
                chieurong = int.Parse(Console.ReadLine());
            } while (chieurong <= 0);
            do
            {
                Console.Write("Sức chứa sân là:");
                succhua =int.Parse( Console.ReadLine());
            } while (succhua <=0);
        }
        public void hien()
        {
            Console.WriteLine("{0,5}{1,10}{2,10}{3,10}{4,10}","masan", "tensan", "chieudai", "chieurong", "succhua");
            Console.WriteLine("{0,5}{1,10}{2,10}{3,10}{4,10}",masan, tensan, chieudai, chieurong, succhua);

            Console.WriteLine();
        }
        public void capnhatsucchua()
        {
            int succhua = 0;
            bool validate;
            Console.WriteLine("Nhấn enter để giữ nguyên mã sân bóng");
            Console.WriteLine("Nhấn enter để giữ nguyên mã sân bóng");
            do
            {
                Console.Write("Nhập sức chứa mới hoặc ấn enter để giữ nguyên sức chứa");
                validate = int.TryParse("0" + Console.ReadLine(), out succhua);
            } while (validate == false);
            if (succhua != 0)
                this.succhua = succhua;
        }
        public String toString()
        {
            return masan + "#" + tensan + "#" + chieudai + "#" + chieurong + "#" + succhua;
        }
    }
}
