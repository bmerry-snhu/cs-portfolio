using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{
    class Program
    {
        static void Main()
        {
            const int numStudents = 10;
            List<Student> students = generateStudents(numStudents);

            foreach (var student in students)
            {
                double avgScore = student.AverageScore();
                Console.WriteLine($"Student {student.StudentID}: {avgScore:F2}");
            }
        }

        static List<Student> generateStudents(int numStudents)
        {
            List<Student> students = new List<Student>();
            Random rand = new Random();

            for (int i = 0; i < numStudents; i++)
            {
                int studentID = i + 1;
                Student student = new Student(studentID);

                for (int examNum = 1; examNum <= 3; examNum++)
                {
                    int score = rand.Next(0, 101);
                    Exam exam = new Exam(examNum, studentID, score);
                    student.addExam(exam);
                }

                students.Add(student);
            }

            return students;
        }
    }   
}