using System;
using System.IO;

namespace Bai05
{
    /*
     * trong tạo class
     *public: Ở mọi nơi (mọi file, mọi project)
     *private: Chỉ trong chính class đó
     *protected: Trong class đó và các lớp kế thừa
     *internal: Trong cùng một project (assembly)
     *protected internal: Trong cùng project hoặc lớp kế thừa ở nơi khác
    */
    class program
    {
        static void Main()
        {
            //này như class quản lý bên c++ vậy <chứa con trỏ đến các đối tượng>
            List<KhuDat> kd = new List<KhuDat>();
            //ko cần phải làm như c++ nữa


            Console.Write("Nhap so luong khu dat: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Nhap thong tin khu dat thu {i + 1}:");
                Console.Write("Chon loai khu dat (0 - Khu Dat, 1 - Nha Pho, 2 - Chung Cu): ");
                int choice = int.Parse(Console.ReadLine());
                KhuDat obj;
                if (choice == 0)
                {
                    obj = new KhuDat();
                }
                else if (choice == 1)
                {
                    obj = new NhaPho();
                }
                else
                {
                    obj = new ChungCu();
                }
                obj.Nhap();

                //add vào list kd
                kd.Add(obj);
            }

            Console.WriteLine("\n=== Thong tin khu dat da nhap ===");
            foreach (var item in kd)
            {
                item.Xuat();
                Console.WriteLine("-----------------------");
            }

            Console.WriteLine("\n=== Tong gia ban cac khu dat ===");
            double tongGiaBan = 0;
            foreach (var item in kd)
            {
                tongGiaBan += item.TongGiaBan();
            }
            Console.WriteLine("Tong gia ban cho 3 loai: " + tongGiaBan + " VND");

            Console.WriteLine("\n=== Khu dat dat chuan ===");
            int temp = 1;
            bool IsFound = false;
            foreach (var item in kd)
            {
                if (item.IsDatChuan())
                {
                    IsFound = true;
                    //lấy thông tin của temp sau đó tăng temp lên 1
                    Console.WriteLine($"Khu dat dat chuan thu {temp++}:");
                    item.Xuat();
                    Console.WriteLine("-----------------------");
                }
            }
            if (!IsFound)
            {
                Console.WriteLine("Khong co khu dat dat chuan!");
            }

            Console.WriteLine("\n=== Tim kiem khu dat ===");
            Console.Write("Nhap dia diem can tim: ");
            string diaDiemTim = Console.ReadLine();
            Console.Write("Nhap gia ban can tim (VND): ");
            int giaBanTim = int.Parse(Console.ReadLine());
            Console.Write("Nhap dien tich can tim (m2): ");
            int dienTichTim = int.Parse(Console.ReadLine());
            IsFound = false;
            foreach (var item in kd)
            {
                if (item.TimKiem(diaDiemTim, giaBanTim, dienTichTim))
                {
                    IsFound = true;
                    Console.WriteLine("Khu dat tim thay:");
                    item.Xuat();
                    Console.WriteLine("-----------------------");
                }
            }
            if (!IsFound)
            {
                Console.WriteLine("Khong tim thay khu dat phu hop!");
            }    
        }
    }
}