using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{
    internal class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public int StudentID { get; }
        private Dictionary<int, Exam> exams = new Dictionary<int, Exam>();

        public Student(int studentID)
        {
            generateName();
            StudentID = studentID;
        }

        public Student(string firstName, string lastName, int studentID)
        {
            FirstName = firstName;
            LastName = lastName;
            StudentID = studentID;
        }

        private void generateName()
        {
            Random rand = new Random();

            List<string> firstNames = new List<string>();
            List<string> lastNames = new List<string>();

            firstNames.Add("Olivia");
            firstNames.Add("Noah");
            firstNames.Add("Amelia");
            firstNames.Add("Liam");
            firstNames.Add("Emma");
            firstNames.Add("Oliver");
            firstNames.Add("Sophia");
            firstNames.Add("Elijah");
            firstNames.Add("Charlotte");
            firstNames.Add("Mateo");

            lastNames.Add("Smith");
            lastNames.Add("Johnson");
            lastNames.Add("Williams");
            lastNames.Add("Brown");
            lastNames.Add("Jones");
            lastNames.Add("Miller");
            lastNames.Add("Davis");
            lastNames.Add("Garcia");
            lastNames.Add("Rodriguez");
            lastNames.Add("Wilson");

            FirstName = firstNames[rand.Next(0, firstNames.Count() - 1)];
            LastName = lastNames[rand.Next(0, lastNames.Count() - 1)];
        }

        public void addExam(Exam exam)
        {
            exams[exam.ExamNum] = exam;
        }

        public double AverageScore()
        {
            if (exams.Count == 0) return 0;

            double totalScore = 0;
            foreach (var exam in exams.Values)
                totalScore += exam.Score;

            return totalScore / exams.Count;
        }
    }
}
