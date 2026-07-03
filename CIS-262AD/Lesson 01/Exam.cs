using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_01
{
    internal class Exam
    {
        public int ExamNum { get; }
        public int StudentID { get; }
        public int Score { get; }

        public Exam(int examNum, int studentID, int score)
        {
            ExamNum = examNum;
            StudentID = studentID;
            Score = score;
        }
    }
}
