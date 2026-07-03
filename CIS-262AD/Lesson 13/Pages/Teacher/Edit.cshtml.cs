using Lesson_13.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Lesson_13.Pages.Teacher
{
    public class EditModel : PageModel
    {
        private ITeacherAdapter _teacherAdapter;
        public EditModel(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        [BindProperty]
        public int TeacherId { get; set; }
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
                DAL.Teacher teacher = _teacherAdapter.GetTeacherById(id);
                if(teacher != null)
                {
                    TeacherId = teacher.TeacherId;
                    FirstName = teacher.FirstName;
                    LastName = teacher.LastName;
                }
            }
        }
        public void OnPost()
        {
            if(ModelState.IsValid)
            {
                DAL.Teacher teacher = new DAL.Teacher();
                teacher.TeacherId = TeacherId;
                teacher.FirstName = FirstName;
                teacher.LastName = LastName;

                if(TeacherId > 0)
                {
                    bool isUpdate = _teacherAdapter.UpdateTeacher(teacher);
                    if(isUpdate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully updated Teacher ID {TeacherId} ({FirstName} {LastName}).";
                    }
                    else
                    {
                        IsSuccess = false;
                    }
                }
                else
                {
                    bool isCreate = _teacherAdapter.InsertTeacher(teacher);
                    if(isCreate)
                    {
                        IsSuccess = true;
                        SuccessMessage = $"You successfully created a new Teacher: {FirstName} {LastName}.";
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
