using E_Store.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Models
{
    public class Memory:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Memory Name")]
        [Required(ErrorMessage = "Memory Name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Memory Name must be between 3 and 50 chars")]
        public string Name { get; set; }

        [Display(Name = "Memory Description")]
        [Required(ErrorMessage = "Memory Description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
