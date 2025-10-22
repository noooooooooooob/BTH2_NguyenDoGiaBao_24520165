using System;

namespace BT04
{
    public class PhanSo : IComparable<PhanSo>
    {
        private int tuSo;
        private int mauSo;
        public int TuSo
        {
            get { return tuSo; }
            set { tuSo = value; }
        }
        public int MauSo
        {
            get { return mauSo; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Mau so khong duoc bang 0.");
                }
                mauSo = value;
            }
        }
        public PhanSo(int tuSo, int mauSo)
        {
            TuSo = tuSo;
            MauSo = mauSo;
            RutGon();
        }
        private void RutGon()
        {
            int gcd = GCD(Math.Abs(tuSo), Math.Abs(mauSo));
            tuSo /= gcd;
            mauSo /= gcd;
            if (mauSo < 0)
            {
                tuSo = -tuSo;
                mauSo = -mauSo;
            }
        }
        private int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
        public static PhanSo operator +(PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.MauSo + b.TuSo * a.MauSo;
            int mauSoMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
        }
        public static PhanSo operator -(PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.MauSo - b.TuSo * a.MauSo;
            int mauSoMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoMoi);
        }
        public static PhanSo operator *(PhanSo a, PhanSo b)
        {
            int tuSoMoi = a.TuSo * b.TuSo;
            int mauSoiMoi = a.MauSo * b.MauSo;
            return new PhanSo(tuSoMoi, mauSoiMoi);
        }
        public static PhanSo operator /(PhanSo a, PhanSo b)
        {
            if (b.TuSo == 0)
                throw new DivideByZeroException("Không thể chia cho phân số có tử = 0!");
            return new PhanSo(a.TuSo * b.MauSo, a.MauSo * b.TuSo);
        }

        // Implementation of IComparable<PhanSo>.CompareTo
        public int CompareTo(PhanSo? other)
        {
            if (other == null) return 1;

            // Compare the two fractions by cross-multiplying to avoid floating-point precision issues
            int left = this.TuSo * other.MauSo;
            int right = other.TuSo * this.MauSo;

            if (left > right) return 1;
            if (left < right) return -1;
            return 0;
        }
    }
}
