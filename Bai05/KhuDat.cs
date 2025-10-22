using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class KhuDat
    {
        //Các thuộc tính
        public string DiaDiem { get; set; }
        public double GiaBan { get; set; }
        public double DienTich { get; set; }


        //Constructor
        public KhuDat()
        {
            DiaDiem = "";
            GiaBan = 0;
            DienTich = 0;
        }
        public KhuDat(string diaDiem, double giaBan, double dienTich)
        {
            DiaDiem = diaDiem;
            GiaBan = giaBan;
            DienTich = dienTich;
        }
        public KhuDat(KhuDat kd)
        {
            DiaDiem = kd.DiaDiem;
            GiaBan = kd.GiaBan;
            DienTich = kd.DienTich;
        }

        //Functions
        public virtual void Nhap()
        {
            Console.Write("Nhap dia diem: ");
            DiaDiem = Console.ReadLine();
            Console.Write("Nhap gia ban (VND): ");
            GiaBan = double.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich (m2): ");
            DienTich = double.Parse(Console.ReadLine());
        }
        public virtual void Xuat()
        {
            Console.WriteLine("Dia diem: " + DiaDiem);
            Console.WriteLine("Gia ban: " + GiaBan + " VND");
            Console.WriteLine("Dien tich: " + DienTich + " m2");
        }
        //nếu lớp con ko override thì lớp con lấy cái này luôn
        public virtual double TongGiaBan()
        {
            return GiaBan;
        }
        public virtual bool IsDatChuan()
        {
            return DienTich > 100;
        }
        public virtual bool TimKiem(string diaDiem, int giaBan, int dienTich)
        {
            //IndexOf() là hàm tìm vị trí xuất hiện đầu tiên của một chuỗi con trong một chuỗi lớn (vẫn phân biệt hoa thường)
            //StringComparison.OrdinalIgnoreCase là tham số để so sánh không phân biệt hoa thường
            //>=0 kiểm tra xem chuỗi con có tồn tại trong chuỗi cha hay không.
            return DiaDiem.IndexOf(diaDiem, StringComparison.OrdinalIgnoreCase) >= 0 && GiaBan <= giaBan && DienTich >= dienTich;
        }
    }
}
