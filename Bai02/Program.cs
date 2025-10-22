using System;

class Program
{
    /*
     * Directory. dùng để thao tác với thư mục
     */
    static void Main()
    {
        Console.Write("Nhap duong dan: ");
        string path = Console.ReadLine();

        //Directory.Exist(string) Kiểm tra đường dẫn tồn tại
        //true → nếu thư mục tại đường dẫn path tồn tại.
        //false → nếu không tồn tại(ví dụ sai đường dẫn, hoặc là file chứ không phải thư mục).
        if (!Directory.Exists(path))
        {
            Console.WriteLine("duong dan khong ton tai.");
            return;
        }

        //ghi ra tiêu đề thư mục
        Console.WriteLine($"\nDirectory of {path}\n");

        //liệt kê tất cả thư mục con và file trong thư mục path
        DirectoryInfo dir = new DirectoryInfo(path);
        FileSystemInfo[] entries = dir.GetFileSystemInfos();

        foreach (var info in entries)
        {
            string date = info.LastWriteTime.ToString("dd/MM/yyyy  hh:mm tt");
            if ((info.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // Là thư mục
                Console.WriteLine("{0,-25}{1,-20}{2}", date, "<DIR>", info.Name);
            }
            else
            {
                // Là file
                long size = new FileInfo(info.FullName).Length;
                //10:N0: định dạng số với dấu phẩy phân cách hàng nghìn, không có chữ số thập phân
                Console.WriteLine("{0,-25}{1,-20:N0}{2}", date, size, info.Name);
            }
        }

        string[] dirs = Directory.GetDirectories(path);
        string[] files = Directory.GetFiles(path);

        long totalSize = 0;
        foreach (string file in files)
        {
            totalSize += new FileInfo(file).Length;
        }

        Console.WriteLine("{0,6} File(s){1,20:N0} bytes", files.Length, totalSize);
        Console.WriteLine("{0,6} Dir(s){1,20:N0} bytes free", dirs.Length,
        // Lấy dung lượng trống của ổ đĩa chứa thư mục path
        new DriveInfo(Path.GetPathRoot(path)).AvailableFreeSpace);

    }
}