using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace efcoreApp.Data
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public string? UserNickname { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPhoneNo { get; set; }
        public byte[]? UserProfilePhoto { get; set; }
       
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth {get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Column(TypeName = "date")]
        public DateTime? UserRegisterationDate { get; set; } = DateTime.UtcNow;

        public ICollection<UserGame>? UserGames { get; set; }
    }
}