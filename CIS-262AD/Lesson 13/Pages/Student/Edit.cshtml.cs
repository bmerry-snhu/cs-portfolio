using Lesson_13.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lesson_13.Pages.Student
{
    public class EditModel : PageModel
    {
        private IStudentAdapter _studentAdapter;
        public EditModel(IStudentAdapter studentAdapter)
        {
            _studentAdapter = studentAdapter;
        }
        [BindProperty]
        public int StudentId { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "First Name is required.")]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First Name cannot exceed 50 characters.")]
        public string? FirstName { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Last Name is required.")]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last Name cannot exceed 50 characters.")]
        public string? LastName { get; set; }
        public bool IsSuccess { get; set; }
        public string? SuccessMessage { get; set; }
        public void OnGet(int id = 0)
        {
            if(id != 0)
            {
                DAL.Student student = _studentAdapter.GetStudentById(id);
                if(student != null)
                {
                    StudentId = student.StudentId;
                    FirstName = student.FirstName;
                    LastName = student.LastName;
                }
            }
        }
        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                DAL.Student student = new DAL.Student();
                student.StudentId = StudentId;
                student.FirstName = FirstName;
                student.LastName = LastName;

                if(StudentId > 0)
                {
                    bool isUpdate = _studentAdapter.UpdateStudent(student);
                    if(isUpdate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully updated Student ID {StudentId} ({FirstName} {LastName}).";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                else
                {
                    bool isCreate = _studentAdapter.InsertStudent(student);
                    if(isCreate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully created a new Student: {FirstName} {LastName}.";
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
                IsSuccess = false;
            }
        }
    }
}
