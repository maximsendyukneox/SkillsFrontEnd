using System.ComponentModel.DataAnnotations;

namespace SkillsFrontEnd
{
    public class SaveEmployeeForm
    {
        [Required(ErrorMessage = "Bitte einen Vornamen eingeben")]
        [StringLength(20, ErrorMessage = "Der Name darf nicht länger als 20 Zeichen sein")]
        [RegularExpression(@"^[A-Za-zöÖüÜäÄß-]*$", ErrorMessage ="Keine Sonderzeichen oder Zahlen erlaubt")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Bitte einen Nachnamen eingeben")]
        [StringLength(20, ErrorMessage = "Der Name darf nicht länger als 20 Zeichen sein")]
        [RegularExpression(@"^[A-Za-zöÖüÜäÄß-]*$", ErrorMessage = "Keine Sonderzeichen oder Zahlen erlaubt")]
        public string LastName { get; set; }
    }
}
