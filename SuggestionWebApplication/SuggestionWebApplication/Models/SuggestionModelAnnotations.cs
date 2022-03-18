using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace SuggestionWebApplication.Models
{
    public class SuggestionModelAnnotations
    {

        [Required]
        [MaxLength(length:75)]
        public string Suggestion { get; set; }

        [MaxLength(length:500)]
        public string Description { get; set; }

        [Required]
        [MinLength(length:1)]
        [Display(Name ="Category")]
        public string CategoryId { get; set; }

    }
}
