using E_Store.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Models
{
    public class CPU:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "CPU Name")]
        [Required(ErrorMessage = "CPU name is required")]
        public string Name { get; set; }

        [Display(Name = "CPU Description")]
        [Required(ErrorMessage = "CPU description is required")]
        public string Description { get; set; }

        //Relationships
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
