using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Bai05
{
    internal class NhaPho : KhuDat
    {
        //Các thuộc tính
        public int SoTang { get; set; }
        public int NamXayDung { get; set; }
        //Constructor
        //: base() gọi constructor của lớp cha
        public NhaPho() : base()
        {
            SoTang = 0;
            NamXayDung = 0;
        }
        public NhaPho(string diaDiem, double giaBan, double dienTich, int soTang, int namXayDung) : base(diaDiem, giaBan, dienTich)
        {
            SoTang = soTang;
            NamXayDung = namXayDung;
        }
        public NhaPho(NhaPho np) : base(np)
        {
            SoTang = np.SoTang;
            NamXayDung = np.NamXayDung;
        }
        //Functions
        //base. gọi hàm của lớp cha
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap so tang: ");
            SoTang = int.Parse(Console.ReadLine());
            Console.Write("Nam xay dung: ");
            NamXayDung = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("So tang: " + SoTang);
            Console.WriteLine("Nam xay dung: " + NamXayDung);
        }
        public override bool IsDatChuan()
        {
            return DienTich > 60 && NamXayDung >= 2019;
        }
    }
}
