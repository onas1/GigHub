using System.ComponentModel.DataAnnotations;

namespace GigHub.Core.ViewModels
{

    public class AccountViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
