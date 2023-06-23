using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Zaj01.ViewModels
{
    public enum ConferenceType
    {
        Workshop,
        Lecture,
        Webinar
    }

    public class ConferenceUserViewModel
    {
        [Display(Name = "Imię")]
        public string ? FirstName { get; set; }
        
        [Display(Name = "Nazwisko")]
        public string LastName { get; set; }

        [Display(Name ="Typ konferencji")]
        [Required]
        public ConferenceType? ConferenceType { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        public IFormFile Photo { get; set; }

        public string ? PhotoPath { get; set; }

    }
}
