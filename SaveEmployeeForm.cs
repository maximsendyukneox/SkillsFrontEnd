using System.ComponentModel.DataAnnotations;

namespace SkillsFrontEnd
{
    public class SaveEmployeeForm
    {
        [Required(ErrorMessage = "Bitte einen Vornamen eingeben")]
        [StringLength(20, ErrorMessage = "Der Name darf nicht länger als 20 Zeichen sein")]
        [RegularExpression(@"^[a-zA-ZöäüÖÄÜß]+([ -][a-zA-ZöäüÖÄÜß]+)?$", ErrorMessage ="Keine Sonderzeichen oder Zahlen erlaubt")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bitte einen Nachnamen eingeben")]
        [StringLength(20, ErrorMessage = "Der Name darf nicht länger als 20 Zeichen sein")]
        [RegularExpression(@"^[a-zA-ZöäüÖÄÜß]+([ -][a-zA-ZöäüÖÄÜß]+)?$", ErrorMessage = "Keine Sonderzeichen oder Zahlen erlaubt")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Kein valides Datumsformat")]
        public DateTime? Date { get; set; }
    }
}
