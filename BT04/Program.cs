using System;
using System.Collections.Generic;

namespace BT04
{
    class Program
    {
        static void Main()
        {
            // ======= PHẦN 1: Hai phân số =======
            Console.WriteLine("Nhập phân số thứ nhất:");
            PhanSo ps1 = NhapPhanSo();
            Console.WriteLine("Nhập phân số thứ hai:");
            PhanSo ps2 = NhapPhanSo();

            Console.WriteLine("\nKết quả:");
            Console.WriteLine($"Tổng: {ps1 + ps2}");
            Console.WriteLine($"Hiệu: {ps1 - ps2}");
            Console.WriteLine($"Tích: {ps1 * ps2}");
            Console.WriteLine($"Thương: {ps1 / ps2}");

            // ======= PHẦN 2: Dãy phân số =======
            Console.Write("\nNhập số lượng phân số: ");
            int n = int.Parse(Console.ReadLine());
            List<PhanSo> ds = new List<PhanSo>();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhập phân số thứ {i + 1}:");
                ds.Add(NhapPhanSo());
            }

            // ✅ Tìm phân số lớn nhất
            PhanSo max = ds[0];
            foreach (var ps in ds)
                if (ps.CompareTo(max) > 0)
                    max = ps;

            Console.WriteLine($"\nPhân số lớn nhất là: {max}");

            // ✅ Sắp xếp tăng dần
            ds.Sort();

            Console.WriteLine("Dãy phân số sau khi sắp xếp tăng dần:");
            foreach (var ps in ds)
                Console.Write(ps + " ");
            Console.WriteLine();
        }

        // ✅ Hàm nhập 1 phân số
        static PhanSo NhapPhanSo()
        {
            Console.Write("  Nhập tử: ");
            int tu = int.Parse(Console.ReadLine());
            Console.Write("  Nhập mẫu: ");
            int mau = int.Parse(Console.ReadLine());
            return new PhanSo(tu, mau);
        }
    }

}
