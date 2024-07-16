// bài 69a
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Đường dẫn đến file cần đọc
        string filePath = "Program.cs"; // Đổi đường dẫn theo vị trí thực tế của file

        // Tìm số dòng trong file
        int lineCount = CountLines(filePath);
        Console.WriteLine($"Số dòng trong file: {lineCount}");

        // Tính số ký tự xuất hiện nhiều nhất
        char mostFrequentChar = FindMostFrequentChar(filePath);
        Console.WriteLine($"Ký tự xuất hiện nhiều nhất: '{mostFrequentChar}'");

        // Tính số từ trong file
        int wordCount = CountWords(filePath);
        Console.WriteLine($"Số từ trong file: {wordCount}");
    }

    // Hàm tìm số dòng trong file
    static int CountLines(string filePath)
    {
        // Đọc tất cả các dòng từ file và đếm số dòng
        string[] lines = File.ReadAllLines(filePath);
        return lines.Length;
    }

    // Hàm tìm ký tự xuất hiện nhiều nhất trong file
    static char FindMostFrequentChar(string filePath)
    {
        // Đọc tất cả nội dung của file
        string content = File.ReadAllText(filePath);
        // Tính tần suất xuất hiện của các ký tự
        var characterFrequency = content
            .GroupBy(c => c) // Nhóm các ký tự giống nhau
            .OrderByDescending(g => g.Count()) // Sắp xếp theo số lượng xuất hiện giảm dần
            .FirstOrDefault(); // Lấy ký tự xuất hiện nhiều nhất

        return characterFrequency?.Key ?? ' '; // Trả về ký tự xuất hiện nhiều nhất hoặc khoảng trắng nếu không có ký tự nào
    }

    // Hàm tính số từ trong file
    static int CountWords(string filePath)
    {
        // Đọc tất cả nội dung của file
        string content = File.ReadAllText(filePath);
        // Tách nội dung thành các từ và đếm số từ
        int wordCount = content.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
        return wordCount;
    }
}
