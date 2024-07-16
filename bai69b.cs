using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Đường dẫn đến file đọc và file ghi
        string inputFilePath = "vd1_read.txt";  // Đổi đường dẫn theo vị trí thực tế của file đọc
        string outputFilePath = "vd1_ghi.txt";  // Đổi đường dẫn theo vị trí thực tế của file ghi

        // Đọc nội dung từ file đầu vào
        string content = ReadFile(inputFilePath);

        // Ghi nội dung vào file đầu ra
        WriteFile(outputFilePath, content);

        Console.WriteLine($"Đã sao chép nội dung từ '{inputFilePath}' sang '{outputFilePath}' thành công.");
    }

    // Hàm đọc nội dung từ file UTF-8
    static string ReadFile(string filePath)
    {
        // Đọc nội dung từ file và trả về dưới dạng chuỗi
        // Đọc file UTF-8 bằng cách chỉ định Encoding.UTF8
        return File.ReadAllText(filePath, System.Text.Encoding.UTF8);
    }

    // Hàm ghi nội dung vào file UTF-8
    static void WriteFile(string filePath, string content)
    {
        // Ghi nội dung vào file với Encoding UTF-8
        File.WriteAllText(filePath, content, System.Text.Encoding.UTF8);
    }
}
