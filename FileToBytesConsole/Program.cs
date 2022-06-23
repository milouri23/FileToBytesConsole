using System;
using System.IO;

namespace FileToBytesConsole;

public static class Program
{
    public static void Main(string[] args)
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string outputDirectory = Path.Combine(currentDirectory, "Output");

        string inputPath = Path.Combine(currentDirectory, "TestFiles", "dummy.pdf");
        string outputPath = Path.Combine(outputDirectory, "bytes.txt");

        byte[] fileBytes = File.ReadAllBytes(inputPath);
        string byteArrayRepresentation = GetByteArrayRepresentation(fileBytes);

        Directory.CreateDirectory(outputDirectory);
        File.WriteAllText(outputPath, byteArrayRepresentation);

        Console.WriteLine($"Output is located in {outputPath}");
        Console.WriteLine();

        ShowPrintInConsoleOption(byteArrayRepresentation);
    }

    private static string GetByteArrayRepresentation(byte[] fileBytes)
        => $"[{string.Join(',', fileBytes)}]";

    private static void ShowPrintInConsoleOption(string byteArrayRepresentation)
    {
        Console.Write("Print array representation in console (n by default) [y/n]: ");
        bool printArray = Console.ReadLine() == "y";

        if (printArray)
            Console.WriteLine(byteArrayRepresentation);

        Console.WriteLine();
        Console.WriteLine("Bye");
    }
}