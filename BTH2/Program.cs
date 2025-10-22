using System;
namespace Bai01
{
    class Program
    {
        static void Main(string[] args)
        {
            int month, year;
            while (true)
            {
                System.Console.Write("Nhap thang: ");
                month = int.Parse(Console.ReadLine());
                System.Console.Write("Nhap nam: ");
                year = int.Parse(Console.ReadLine());

                if (IsValid(month, year))
                {
                    Console.WriteLine();
                    DateTime date = new DateTime(year, month, 1);
                    string Temp = date.ToString("'Month: 'MM/yyyy");
                    Console.WriteLine(Temp);
                    break;
                }
                Console.WriteLine("Thang hoac nam khong hop le, vui long nhap lai!");
            }


            // ghi dòng tiêu đề các ngày trong tuần
            Console.WriteLine(
                "{0,-5}{1,-5}{2,-5}{3,-5}{4,-5}{5,-5}{6,-5}",
                "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat"
            );

            Xuat(month, year);
        }

        // Hàm kiểm tra tính hợp lệ của tháng và năm
        static bool IsValid(int thang, int nam)
        {
            if (nam <= 0) return false;
            if (thang < 1 || thang > 12) return false;
            return true;
        }
        // Hàm xuất lịch tháng
        static void Xuat(int thang, int nam)
        {
            DateTime date = new DateTime(nam, thang, 1);
            int DayInMonth = DateTime.DaysInMonth(nam, thang);
            int DayInWeek = (int)date.DayOfWeek;

            //cac khoảng trắng trước ngày đầu tiên
            for (int i = 0; i < DayInWeek; i++)
            {
                Console.Write("{0,-5}", " ");
            }

            for (int i = 1; i <= DayInMonth; i++)
            {
                Console.Write("{0,-5}", i);

                //xuong dong sau khi in thu 7
                //ví dụ: nếu ngày đầu tiên là thứ 4 (DayInWeek = 3) + (i = 4) thì sẽ in xong thứ 7 (% 7)
                if ((i + DayInWeek) % 7 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}