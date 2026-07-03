using Microsoft.AspNetCore.Mvc;
using Lesson_13.DAL;

namespace Lesson_13
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private ITeacherAdapter _teacherAdapter;
        public TeacherController(ITeacherAdapter teacherAdapter)
        {
            _teacherAdapter = teacherAdapter;
        }
        [HttpGet]
        public IEnumerable<Teacher> GetTeachers()
        {
            return _teacherAdapter.GetAllTeachers();
        }
        [HttpPost]
        public IActionResult InsertTeacher(Teacher teacher)
        {
            bool isSuccess = _teacherAdapter.InsertTeacher(teacher);

            if(isSuccess)
            {
                return Ok(teacher);
            }
            else
            {
                throw new Exception("Error inserting teacher.");
            }
        }
        [HttpPut]
        public IActionResult UpdateTeacher(Teacher teacher)
        {
            bool isSuccess = _teacherAdapter.UpdateTeacher(teacher);

            if(isSuccess)
            {
                return Ok(teacher);
            }
            else
            {
                throw new Exception("Error updating teacher.");
            }
        }
        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            bool isSuccess = _teacherAdapter.DeleteTeacherById(id);

            if(isSuccess)
            {
                return Ok();
            }
            else
            {
                throw new Exception("Error deleting teacher.");
            }
        }
    }
}
