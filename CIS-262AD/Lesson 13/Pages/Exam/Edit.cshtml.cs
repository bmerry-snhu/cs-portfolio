using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Lesson_13.DAL;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson_13.Pages.Exam
{
    public class EditModel : PageModel
    {
        private IExamAdapter _examAdapter;
        private IStudentAdapter _studentAdapter;
        public EditModel(IExamAdapter examAdapter, IStudentAdapter studentAdapter)
        {
            _examAdapter = examAdapter;
            _studentAdapter = studentAdapter;
        }
        [BindProperty]
        public int ExamId { get; set; }
        public List<SelectListItem>? StudentOptions { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Student")]
        [Range(1,double.MaxValue,
        ErrorMessage = "Please select a student.")]
        public int StudentId { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Exam Score (%)")]
        [Range(0,100,
        ErrorMessage = "Exam scores must be between 0 and 100.")]
        public int Score { get; set; }
        public bool IsSuccess { get; set; }
        public string? SuccessMessage { get; set; }
        public void OnGet(int id = 0)
        {
            SetupStudentOptions();
            if(id != 0)
            {
                DAL.Exam exam = _examAdapter.GetExamById(id);
                if(exam != null)
                {
                    ExamId = exam.ExamId;
                    StudentId = exam.StudentId;
                    Score = exam.Score;
                }
            }
        }
        public void SetupStudentOptions()
        {
            StudentOptions = new List<SelectListItem>();
            IEnumerable<DAL.Student> students = _studentAdapter.GetAllStudents();
            foreach(DAL.Student student in students)
            {
                SelectListItem itemToAdd = new SelectListItem();
                itemToAdd.Text = student.FirstName + " " + student.LastName;
                itemToAdd.Value = student.StudentId.ToString();
                StudentOptions.Add(itemToAdd);
            }
        }
        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                DAL.Exam exam = new DAL.Exam();
                exam.ExamId = ExamId;
                exam.StudentId = StudentId;
                exam.Score = Score;

                DAL.Student student = _studentAdapter.GetStudentById(StudentId);

                if(ExamId > 0)
                {
                    bool isUpdate = _examAdapter.UpdateExam(exam);
                    if(isUpdate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully updated the exam record for Student ID {StudentId} ({student.FirstName} {student.LastName}) with an exam score of {Score}.";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                else
                {
                    bool isCreate = _examAdapter.InsertExam(exam);
                    if(isCreate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully created an exam record for Student ID {StudentId} ({student.FirstName} {student.LastName}) with an exam score of {Score}.";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                IsSuccess = true;
            }
            else
            {
                SetupStudentOptions();
                IsSuccess = false;
            }
        }
    }
}
