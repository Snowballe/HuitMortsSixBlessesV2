using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.Web.ViewModels
{
    public class TriangleVM
    {
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        public int? X1 { get; set; }
        [Required]
        public int? X2 { get; set; }
        [Required]
        public int? X3 { get; set; }
        [Required]
        public int? Y1 { get; set; }
        [Required]
        public int? Y2 { get; set; }
        [Required]
        public int? Y3 { get; set; }
    }
}
