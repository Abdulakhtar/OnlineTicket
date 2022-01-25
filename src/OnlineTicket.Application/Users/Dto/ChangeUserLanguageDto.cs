using System.ComponentModel.DataAnnotations;

namespace OnlineTicket.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}