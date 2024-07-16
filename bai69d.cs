using System;
using System.IO;

class Program
{
    static void Main()
    {
        // Tạo mảng 2 chiều các số thực 8 byte (double) để ghi vào file
        double[,] arrayToWrite = new double[,]
        {
            { 1.1, 2.2, 3.3 },
            { 4.4, 5.5, 6.6 },
            { 7.7, 8.8, 9.9 }
        };

        // Đường dẫn đến file nhị phân
        string filePath = "a2d.dat";

        // Ghi mảng 2 chiều vào file nhị phân
        WriteArrayToBinaryFile(filePath, arrayToWrite);

        // Đọc lại mảng 2 chiều từ file nhị phân
        double[,] arrayRead = ReadArrayFromBinaryFile(filePath);

        // Hiển thị mảng đọc được để kiểm tra
        Console.WriteLine("Mảng 2 chiều đọc từ file:");
        Print2DArray(arrayRead);
    }

    // Hàm ghi mảng 2 chiều các số thực 8 byte vào file nhị phân
    static void WriteArrayToBinaryFile(string filePath, double[,] array)
    {
        using (var stream = File.Open(filePath, FileMode.Create))
        using (var writer = new BinaryWriter(stream))
        {
            int rows = array.GetLength(0);
            int cols = array.GetLength(1);
            
            // Ghi kích thước của mảng
            writer.Write(rows);
            writer.Write(cols);

            // Ghi dữ liệu của mảng vào file
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    writer.Write(array[i, j]);
                }
            }
        }
    }

    // Hàm đọc mảng 2 chiều các số thực 8 byte từ file nhị phân
    static double[,] ReadArrayFromBinaryFile(string filePath)
    {
        using (var stream = File.Open(filePath, FileMode.Open))
        using (var reader = new BinaryReader(stream))
        {
            // Đọc kích thước của mảng
            int rows = reader.ReadInt32();
            int cols = reader.ReadInt32();

            double[,] array = new double[rows, cols];

            // Đọc dữ liệu của mảng từ file
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    array[i, j] = reader.ReadDouble();
                }
            }

            return array;
        }
    }

    // Hàm hiển thị mảng 2 chiều
    static void Print2DArray(double[,] array)
    {
        int rows = array.GetLength(0);
        int cols = array.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"{array[i, j]:F1} ");
            }
            Console.WriteLine();
        }
    }
}
