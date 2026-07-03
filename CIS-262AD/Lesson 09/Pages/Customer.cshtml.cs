using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Lesson_09.Pages
{
    public class CustomerModel : PageModel
    {
        [BindProperty]
        [Required]
        [DisplayName("First Name")]
        public string? FirstName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Business Name")]
        public string? BusinessName { get; set; }
        public List<SelectListItem>? BusinessTypeOptions { get; set; }
        [BindProperty]
        [Required]
        [DisplayName("Business Type")]
        [Range(1, double.MaxValue,
        ErrorMessage = "Please select a business type.")]
        public string? BusinessType { get; set; }
        public bool IsSuccess { get; set; }
        public void OnGet()
        {
            SetupBusinessOptions();
        }
        public void SetupBusinessOptions()
        {
            BusinessTypeOptions = new List<SelectListItem>();
            BusinessTypeOptions.Add(new SelectListItem("", "0"));
            BusinessTypeOptions.Add(new SelectListItem("Services", "1"));
            BusinessTypeOptions.Add(new SelectListItem("General Business", "2"));
            BusinessTypeOptions.Add(new SelectListItem("Hospitality", "3"));
            BusinessTypeOptions.Add(new SelectListItem("Information Technology", "4"));
            BusinessTypeOptions.Add(new SelectListItem("Government", "5"));
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                IsSuccess = true;
            }
            else
            {
                SetupBusinessOptions();
                IsSuccess = false;
            }
        }
    }
}
