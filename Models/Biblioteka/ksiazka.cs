

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvancedProgramming_Lesson1.Models.Bookstore
{
    public class ksiazka
    {
        [Display(Name = "#")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nazwa książki jest wymagana")]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Rok wydania jest wymagany")]
        [Range(1, int.MaxValue, ErrorMessage = "Nieprawidłowy rok wydania")]
        [Display(Name = "Rok wydania")]
        public int YearOfRelease { get; set; }
        [Required(ErrorMessage = "Gatunek jest wymagany")]
        [Display(Name = "Gatunek")]
        public int GenreId { get; set; }
        [Display(Name = "Gatunek")]
        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Autor jest wymagany")]
        [Display(Name = "Autor")]
        public int AuthorId { get; set; }
        [Display(Name = "Autor")]
        public Author Author { get; set; }
        [Required(ErrorMessage = "Ilość stron jest wymagana")]
        [Range(1, int.MaxValue, ErrorMessage = "Nieprawidłowa ilość stron")]
        [Display(Name = "Ilość strona")]
        public int PagesCount { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        [Range(1, int.MaxValue, ErrorMessage = "Nieprawidłowa cena")]
        [Column(TypeName = "decimal(6, 2)")]
        [Display(Name = "Cena")]
        public decimal ListPrice { get; set; }
    }
}