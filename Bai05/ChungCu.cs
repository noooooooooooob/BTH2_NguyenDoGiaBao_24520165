using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai05
{
    internal class ChungCu : KhuDat
    {
        public int Tang { get; set; }

        //Constructor
        public ChungCu() : base()
        {
            Tang = 0;
        }
        public ChungCu(string diaDiem, double giaBan, double dienTich, int tang) : base(diaDiem, giaBan, dienTich)
        {
            Tang = tang;
        }
        public ChungCu(ChungCu cc) : base(cc)
        {
            Tang = cc.Tang;
        }
        //Functions
        public override void Nhap()
        {
            base.Nhap();
            Console.Write("Nhap tang: ");
            Tang = int.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            base.Xuat();
            Console.WriteLine("Tang: " + Tang);
        }
        public override bool IsDatChuan()
        {
            return false;
        }
    }
}
