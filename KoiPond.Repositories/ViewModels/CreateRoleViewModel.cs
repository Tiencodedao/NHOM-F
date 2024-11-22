using System.ComponentModel.DataAnnotations;

namespace KoiPond.Repositories.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
