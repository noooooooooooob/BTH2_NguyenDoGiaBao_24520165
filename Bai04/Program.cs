using System;
using System.Collections.Generic;
using Bai04;

class program
{
    //static PhanSo NhapPhanSo()
    //{
    //    string[] parts = Console.ReadLine().Split();
    //    int tu = int.Parse(parts[0]);
    //    int mau = int.Parse(parts[1]);
    //    return new PhanSo(tu, mau);
    //}
    static void Main()
    {
        Console.WriteLine("Nhap phan so thu nhat:");
        PhanSo ps1 = new PhanSo();
        ps1.Nhap();
        Console.WriteLine("\nNhap phan so thu hai:");
        PhanSo ps2 = new PhanSo();
        ps2.Nhap();


        Console.WriteLine($"\nTong: {ps1 + ps2}");
        Console.WriteLine($"Hieu: {ps1 - ps2}");
        Console.WriteLine($"Tich: {ps1 * ps2}");
        Console.WriteLine($"Thuong: {ps1 / ps2}");



        //nhập 1 danh sách phân số
        Console.Write("\nNhap so luong phan so: ");
        int n = int.Parse(Console.ReadLine());
        List<PhanSo> ds = new List<PhanSo>();


        //!!!!!! Ko dùng cách này vì nó tham chiếu đến cùng 1 đối tượng
        //sửa 1 cái là sưa đổi tất cả
        //PhanSo Temp = new PhanSo();
        //for (int i = 0; i < n; i++)
        //{
        //    Console.WriteLine($"Phan so thu {i}: ");
        //    Temp.Nhap();
        //    ds.Add(Temp);
        //}

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPhan so thu {i + 1}: ");
            PhanSo temp = new PhanSo();
            temp.Nhap();
            ds.Add(temp);
        }


        PhanSo max = ds[0];
        foreach (var ps in ds)
            if (ps.CompareTo(max) > 0) max = ps;

        Console.WriteLine($"\nPhan so lon nhat: {max}");

        //Sắp xếp tăng dần
        ds.Sort();
        Console.WriteLine("\nDanh sach tang dan:");
        foreach (var ps in ds)
            Console.WriteLine(ps);
    }
}