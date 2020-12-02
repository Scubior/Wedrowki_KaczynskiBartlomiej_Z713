using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Wedrowki.Models
{
    [Table("dbo.PIESZE_WEDROWKI")]
    public class WedrowkaModel
    {
        [Key]
        public Int16 IdWedrowki { get; set; }

        [Required(ErrorMessage = "Musisz podać nazwę wędrówki")]
        public String Nazwa { get; set; }

        [Required(ErrorMessage = "Musisz podać opis wędrówki")]
        public String Opis { get; set; }

        [Required(ErrorMessage = "Musisz podać miejsce startu")]
        [Display(Name = "Miejsce Startu")]
        public String MiejsceStartu { get; set; }

        [Required(ErrorMessage = "Musisz podać miejsce docelowe")]
        [Display(Name = "Miejsce Docelowe")]
        public String MiejsceDocelowe { get; set; }

        [Required(ErrorMessage = "Musisz podać liczbę przebytych kilemetrów")]
        [Display(Name = "Liczba kilometrów")]
        public Int16 LiczbaKm { get; set; }

        [Required(ErrorMessage = "Musisz podać datę startu")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data startu")]
        public DateTime DataStartu { get; set; }

        [Required(ErrorMessage = "Musisz podać datę końcową")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Data zakończenia")]
        public DateTime DataKonca { get; set; }
        public String Zdj1 { get; set; }
        public String Zdj2 { get; set; }
        public String Zdj3 { get; set; }
        public String Zdj4 { get; set; }
        public String Zdj5 { get; set; }
        public String Zdj6 { get; set; }
        public String Film1 { get; set; }

        [NotMapped]
        public HttpPostedFileBase Zdjecie1 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zdjecie2 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zdjecie3 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zdjecie4 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zdjecie5 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Zdjecie6 { get; set; }
        [NotMapped]
        public HttpPostedFileBase Fil1 { get; set; }
    }
}
