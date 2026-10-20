using System.ComponentModel.DataAnnotations;

namespace GamersPC.Models
{
    public class EditViewModel
    {
        public string? Id{get;set;}
        public string? UserName {get; set;}

        public string? FullName {get; set;}
        
        [EmailAddress]
        public string? Email{get; set;}

        [DataType(DataType.Password)]
        public string? Password{get; set;}

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Password does not match.")]
        public string? ConfirmPassword {get; set;}

        public IList<string> SelectedRoles {get; set;} = null!;
    }
}