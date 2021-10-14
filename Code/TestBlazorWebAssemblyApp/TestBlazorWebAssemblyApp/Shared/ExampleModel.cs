using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBlazorWebAssemblyApp.Shared
{
    public class ExampleModel
    {
        [Required(ErrorMessage = "Trường Identifier là bắt buộc")]
        [StringLength(16, ErrorMessage = "Identifier too long (16 character limit).")]
        public string Identifier { get; set; }

        public string Description { get; set; }

        [Required]
        public string Classification { get; set; }

        [Range(1, 100000, ErrorMessage = "Accommodation invalid (1-100000).")]
        public int MaximumAccommodation { get; set; }

        [Required]
        [Range(typeof(bool), "true", "true",
            ErrorMessage = "This form disallows unapproved ships.")]
        public bool IsValidatedDesign { get; set; }

        [Required(ErrorMessage = "Trường Production Date là bắt buộc")]
        public DateTime ProductionDate { get; set; }
    }
}
