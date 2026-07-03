using Microsoft.AspNetCore.Mvc;
using Lesson_13.DAL;

namespace Lesson_13
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        private IExamAdapter _examAdapter;
        public ExamController(IExamAdapter examAdapter)
        {
            _examAdapter = examAdapter;
        }
        [HttpGet]
        public IEnumerable<Exam> GetExams()
        {
            return _examAdapter.GetAllExams();
        }
        [HttpPost]
        public IActionResult InsertExam(Exam exam)
        {
            bool isSuccess = _examAdapter.InsertExam(exam);

            if(isSuccess)
            {
                return Ok(exam);
            }
            else
            {
                throw new Exception("Error inserting exam.");
            }
        }
        [HttpPut]
        public IActionResult UpdateExam(Exam exam)
        {
            bool isSuccess = _examAdapter.UpdateExam(exam);

            if(isSuccess)
            {
                return Ok(exam);
            }
            else
            {
                throw new Exception("Error updating exam.");
            }
        }
        [HttpDelete]
        public IActionResult DeleteExam(int id)
        {
            bool isSuccess = _examAdapter.DeleteExamById(id);

            if(isSuccess)
            {
                return Ok();
            }
            else
            {
                throw new Exception("Error deleting exam.");
            }
        }
    }
}
