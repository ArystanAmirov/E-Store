using E_Store.Data;
using E_Store.Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Models
{
    public class NewPhoneVM
    {
        public int Id { get; set; }

        [Display(Name = "Phone name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Display(Name = "Phone description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Display(Name = "Phone image URL")]
        [Required(ErrorMessage = "Phone image URL is required")]
        public string ImageURL { get; set; }

        [Display(Name = "Select a colour")]
        [Required(ErrorMessage = "Phone colour is required")]
        public PhoneColour PhoneColour { get; set; }

        [Display(Name = "Select a CPU")]
        [Required(ErrorMessage = "Phone CPU is required")]
        public int CPUId { get; set; }

        [Display(Name = "Select a memory")]
        [Required(ErrorMessage = "Phone memory is required")]
        public int MemoryId { get; set; }
    }
}
