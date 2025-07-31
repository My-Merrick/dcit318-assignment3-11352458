using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = @"C:\Users\ICONIC\Desktop\L300 SECOND SEMESTER\Programming 2 DCIT318\ASSIGNMENT3\SchoolGradingSystem\SchoolGradingSystem\bin\Debug\net8.0\students.txt";
            // Provide the path to your input file
            string outputFilePath = "report.txt";  // Output file will be created

            StudentResultProcessor processor = new StudentResultProcessor();

            try
            {
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                processor.WriteReportToFile(students, outputFilePath);

                Console.WriteLine("Report generated successfully:");
                Console.WriteLine($"Output file: {Path.GetFullPath(outputFilePath)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Input file '{inputFilePath}' not found.");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Invalid score format: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Missing fields: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
