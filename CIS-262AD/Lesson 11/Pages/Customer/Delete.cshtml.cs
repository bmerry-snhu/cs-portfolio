using Lesson_11.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lesson_11.Pages.Customer
{
    public class DeleteModel : PageModel
    {
        private ICustomerAdapter _customerAdapater;
        public int Id { get; set; }
        public DeleteModel(ICustomerAdapter customerAdapter)
        {
            _customerAdapater = customerAdapter;
        }
        public bool IsSuccess = false;
        public void OnGet(int id = 0)
        {
            Id = id;
            if(id > 0)
            {
                bool isDelete = _customerAdapater.DeleteCustomerById(id);
                if(isDelete)
                {
                    IsSuccess = true;
                }
                else
                {
                    IsSuccess = false;
                }
            }
            else
            {
                IsSuccess = false;
            }
        }
    }
}
