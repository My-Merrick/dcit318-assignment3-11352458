using System;
using System.Collections.Generic;
using System.IO;

namespace SchoolGradingSystem
{
    public class StudentResultProcessor
    {
        public List<Student> ReadStudentsFromFile(string inputFilePath)
        {
            List<Student> students = new List<Student>();

            using (StreamReader reader = new StreamReader(inputFilePath))
            {
                string? line;
                int lineNumber = 0;

                while ((line = reader.ReadLine()) != null)
                {
                    lineNumber++;
                    string[] parts = line.Split(',');

                    if (parts.Length != 3)
                    {
                        throw new MissingFieldException($"Line {lineNumber}: Expected 3 fields, got {parts.Length}");
                    }

                    int id;
                    if (!int.TryParse(parts[0].Trim(), out id))
                    {
                        throw new FormatException($"Line {lineNumber}: Invalid student ID format.");
                    }

                    string name = parts[1].Trim();

                    int score;
                    if (!int.TryParse(parts[2].Trim(), out score))
                    {
                        throw new InvalidScoreFormatException($"Line {lineNumber}: Score is not a valid integer.");
                    }

                    students.Add(new Student(id, name, score));
                }
            }

            return students;
        }

        public void WriteReportToFile(List<Student> students, string outputFilePath)
        {
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var student in students)
                {
                    string line = $"{student.FullName} (ID: {student.Id}): Score = {student.Score}, Grade = {student.GetGrade()}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
