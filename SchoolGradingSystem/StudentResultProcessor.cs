using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SchoolGradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            var students = new List<Student>();
            
            using (var reader = new StreamReader(inputFilePath))
            {
                int lineNumber = 0;
                string line;
                
                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    
                    try
                    {
                        // Split each line by comma and validate the number of fields
                        string[] fields = line.Split(',');
                        
                        if (fields.Length != 3)
                        {
                            throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, but found {fields.Length}. Line: '{line}'");
                        }
                        
                        // Try converting the score to an integer
                        if (!int.TryParse(fields[2].Trim(), out int score))
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Score '{fields[2].Trim()}' cannot be converted to an integer. Line: '{line}'");
                        }
                        
                        // Validate score range
                        if (score < 0 || score > 100)
                        {
                            throw new InvalidScoreFormatException($"Line {lineNumber}: Score {score} is out of valid range (0-100). Line: '{line}'");
                        }
                        
                        // Create and add student
                        var student = new Student(
                            int.Parse(fields[0].Trim()),
                            fields[1].Trim(),
                            score
                        );
                        
                        students.Add(student);
                    }
                    catch (MissingFieldException)
                    {
                        throw; // Re-throw to be handled by caller
                    }
                    catch (InvalidScoreFormatException)
                    {
                        throw; // Re-throw to be handled by caller
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Line {lineNumber}: Unexpected error processing line '{line}': {ex.Message}");
                    }
                }
            }
            
            return students;
        }
        
        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (var writer = new StreamWriter(outputFilePath))
            {
                writer.WriteLine("=== Student Grade Report ===");
                writer.WriteLine($"Generated on: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
                writer.WriteLine($"Total Students: {students.Count}");
                writer.WriteLine();
                
                foreach (var student in students)
                {
                    string grade = student.GetGrade();
                    writer.WriteLine($"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {grade}");
                }
                
                writer.WriteLine();
                writer.WriteLine("=== Grade Distribution ===");
                var gradeDistribution = new Dictionary<string, int>();
                
                foreach (var student in students)
                {
                    string grade = student.GetGrade();
                    if (gradeDistribution.ContainsKey(grade))
                        gradeDistribution[grade]++;
                    else
                        gradeDistribution[grade] = 1;
                }
                
                foreach (var kvp in gradeDistribution.OrderByDescending(x => x.Key))
                {
                    writer.WriteLine($"Grade {kvp.Key}: {kvp.Value} student(s)");
                }
            }
        }
    }
}
