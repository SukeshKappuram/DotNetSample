using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ekart.Models
{
    public class Category
    {
        [Display(Name = "Catagory Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:100)]
        [Display(Name = "Catagory Name")]
        public string CategoryName { get; set; }
    }
}
