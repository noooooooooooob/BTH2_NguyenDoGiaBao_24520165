using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai04
{
    //IComparable<PhanSo> mới sắp xếp dc
    internal class PhanSo : IComparable<PhanSo>
    {
        public int Tu {  get; set; }
        public int Mau { get; set; }

        public PhanSo()
        {
            Tu = 0;
            Mau = 1;
        }
        public PhanSo(int tu, int mau)
        {
            Tu = tu;
            Mau = mau;
            RutGon();
        }

        public PhanSo Nhap()
        {
            Console.Write("Nhap tu so: ");
            Tu = int.Parse(Console.ReadLine());
            do
            {
                Console.Write("Nhap mau so (khac 0): ");
                Mau = int.Parse(Console.ReadLine());
            } while (Mau == 0);

            return this;
        }

        public void RutGon()
        {
            int ucln = UCLN(Math.Abs(Tu), Math.Abs(Mau));
            Tu /= ucln;
            Mau /= ucln;
            if (Mau < 0)
            {
                Mau = -Mau;
                Tu = -Tu;
            }
        }
        //Vì chỉ cần dùng trong này nên để private cho gọn
        private int UCLN(int a, int b)
        {
            return b == 0 ? a : UCLN(b, a % b);
            /* ==> Cách khác
            while (b != 0)
            {
            int r = a % b;
            a = b;
            b = r;
            }
            return a;
            */
        }

        //
        //nạp chồng toán tử
        //

        //Cộng
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.Tu = a.Tu * b.Mau + b.Tu * a.Mau;
            c.Mau = a.Mau * b.Mau;
            c.RutGon();
            return c;
        }
        //public static PhanSo operator +(PhanSo a, PhanSo b)
        //  => new PhanSo(a.Tu * b.Mau + b.Tu * a.Mau, a.Mau * b.Mau);
        
        //Trừ
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.Tu = a.Tu * b.Mau - b.Tu * a.Mau;
            c.Mau = a.Mau * b.Mau;
            c.RutGon();
            return c;
        }
        //public static PhanSo operator -(PhanSo a, PhanSo b)
        //  => new PhanSo(a.Tu * b.Mau - b.Tu * a.Mau, a.Mau * b.Mau);

        //Nhân
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.Tu = a.Tu * b.Tu;
            c.Mau = a.Mau * b.Mau;
            c.RutGon();
            return c;
        }
        //public static PhanSo operator *(PhanSo a, PhanSo b)
        //  => new PhanSo(a.Tu * b.Tu, a.Mau * b.Mau);

        //Chia
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            PhanSo c = new PhanSo();
            c.Tu = a.Tu * b.Mau;
            c.Mau = a.Mau * b.Tu;
            c.RutGon();
            return c;
        }
        //public static PhanSo operator /(PhanSo a, PhanSo b)
        //  => new PhanSo(a.Tu * b.Mau, a.Mau * b.Tu);

        //So sánh (mới sắp xếp dc)
        public int CompareTo(PhanSo other)
        {
            // So sánh bằng cách quy đồng
            int left = this.Tu * other.Mau;
            int right = other.Tu * this.Mau;
            return left.CompareTo(right);
        }




        //override ToString()
        //hàm này tự động dc gọi khi ta dùng Console.WriteLine(có cái class phanSo)
        public override string ToString()
        {
            if (Tu == 0)
                return "0";
            if (Mau == 1)
                return $"{Tu}";
            return $"{Tu}/{Mau}";
        }
    }
}
