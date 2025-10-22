using System;
using System.Collections.Generic;

namespace Bai03
{
    class Program
    {
        static void Main(string[] args)
        {
            int Hang, Cot;
            while (true)
            {
                Console.Write("Nhap so hang: ");
                Hang = int.Parse(Console.ReadLine());
                Console.Write("Nhap so cot: ");
                Cot = int.Parse(Console.ReadLine());

                if (Hang > 0 && Cot > 0)
                {
                    break;
                }
                Console.WriteLine("So hang hoac so cot khong hop le, vui long nhap lai!");
            }

            int[,] a = new int[Hang, Cot];
            Console.WriteLine("Nhap ma tran: ");
            for (int i = 0; i < Hang; i++)
            {
                Console.WriteLine("Nhap hang thu {0}:", i);
                for (int j = 0; j < Cot; j++)
                {
                    Console.Write("[" + "{0},{1}", i, j + "]: ");
                    a[i, j] = int.Parse(Console.ReadLine());
                }
            }

            Console.WriteLine("Ma tran vua nhap la:");
            XuatMaTran(a, Hang, Cot);
            Console.Write("\nNhap phan tu can tim: ");
            int temp = int.Parse(Console.ReadLine());
            TimPhanTuTrongMaTran(temp, a, Hang, Cot);
            XuatSoNguyenToTrongMaTran(a, Hang, Cot);
            DongCoNhieuPrimeNhat(a, Hang, Cot);
        }
        static void XuatMaTran(int[,] a, int hang, int cot)
        {
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    Console.Write("{0,-10}",$"[{i},{j}]{a[i,j]}");
                }
                Console.WriteLine();
            }
        }
        static void TimPhanTuTrongMaTran(int PhanTuCanTim, int[,] a, int hang, int cot)
        {
            bool found = false;
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (a[i, j] == PhanTuCanTim)
                    {
                        found = true;
                        Console.WriteLine("{0} nam o vi tri [{1},{2}]", PhanTuCanTim, i, j);
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("Khong tim thay phan tu {0} trong ma tran", PhanTuCanTim);
            }
        }
        static bool IsPrime(int n)
        {
            if (n < 2)
            {
                return false;
            }
            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0)
                { 
                    return false;
                }
            }
            return true;
        }
        static void XuatSoNguyenToTrongMaTran(int[,] a, int hang, int cot)
        {
            Console.Write("Cac so nguyen to trong ma tran la: { ");
            bool first = true;
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (IsPrime(a[i, j]))
                    {
                        if (!first)
                            Console.Write(", ");
                        Console.Write(a[i, j]);
                        first = false;
                    }
                }
            }
            if (first)
                Console.Write("Khong co so nguyen to nao");
            Console.WriteLine(" }");
        }
        static void DongCoNhieuPrimeNhat(int[,] a, int hang, int cot)
        {
            bool PrimeFound = false;
            //mang luu so luong so nguyen to tren moi dong (Có giá trị khởi tạo mặc định là 0)
            int[] DongPrimeCount = new int[hang];

            int MaxCount = 0;
            for (int i = 0; i < hang; i++)
            {
                for (int j = 0; j < cot; j++)
                {
                    if (IsPrime(a[i, j]))
                    {
                        DongPrimeCount[i]++;
                    }
                }
                if (DongPrimeCount[i] > MaxCount)
                {
                    PrimeFound = true;
                    MaxCount = DongPrimeCount[i];
                }
            }
            Console.Write("Dong co nhieu so nguyen to nhat la: ");
            if (!PrimeFound)
            {
                Console.WriteLine("Khong co so nguyen to nao trong ma tran");
                return;
            }
            for (int i = 0; i < hang; i++)
            {
                if (DongPrimeCount[i] == MaxCount && MaxCount > 0)
                {
                    Console.Write(i + " ");
                }
            }
        }
        
    }
}