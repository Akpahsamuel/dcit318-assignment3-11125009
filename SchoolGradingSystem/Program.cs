using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== School Grading System ===");
            Console.WriteLine();
            
            string inputFilePath = "students_input.txt";
            string outputFilePath = "grade_report.txt";
            
            try
            {
                // Create sample input file if it doesn't exist
                CreateSampleInputFile(inputFilePath);
                
                Console.WriteLine($"Reading student data from: {inputFilePath}");
                
                // i. Call ReadStudentsFromFile(...) and pass the input file path
                var processor = new StudentResultProcessor();
                List<Student> students = processor.ReadStudentsFromFile(inputFilePath);
                
                Console.WriteLine($"Successfully read {students.Count} student records.");
                Console.WriteLine();
                
                // ii. Call WriteReportToFile(...) and pass the student list and output file path
                Console.WriteLine($"Writing grade report to: {outputFilePath}");
                processor.WriteReportToFile(students, outputFilePath);
                
                Console.WriteLine("Grade report generated successfully!");
                Console.WriteLine();
                
                // Display the report content
                Console.WriteLine("=== Generated Report Content ===");
                string[] reportLines = File.ReadAllLines(outputFilePath);
                foreach (string line in reportLines)
                {
                    Console.WriteLine(line);
                }
                
                Console.WriteLine();
                Console.WriteLine("=== System Summary ===");
                Console.WriteLine($"Input file: {inputFilePath}");
                Console.WriteLine($"Output file: {outputFilePath}");
                Console.WriteLine($"Students processed: {students.Count}");
                Console.WriteLine($"Report generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine($"Error: Input file not found: {ex.Message}");
            }
            catch (InvalidScoreFormatException ex)
            {
                Console.WriteLine($"Error: Invalid score format: {ex.Message}");
            }
            catch (MissingFieldException ex)
            {
                Console.WriteLine($"Error: Missing field in student record: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected error: {ex.Message}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        static void CreateSampleInputFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                string[] sampleData = {
                    "101,Alice Smith,84",
                    "102,Bob Johnson,72",
                    "103,Carol Davis,95",
                    "104,David Wilson,58",
                    "105,Eva Brown,67",
                    "106,Frank Miller,91",
                    "107,Grace Lee,76",
                    "108,Henry Taylor,45"
                };
                
                File.WriteAllLines(filePath, sampleData);
                Console.WriteLine($"Created sample input file: {filePath}");
                Console.WriteLine();
            }
        }
    }
}
