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
    public class Phone:IEntityBase
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImageURL { get; set; }
        public PhoneColour PhoneColour { get; set; }

        //CPU
        public int CPUId { get; set; }
        [ForeignKey("CPUId")]
        public CPU CPU { get; set; }

        //Memory
        public int MemoryId { get; set; }
        [ForeignKey("MemoryId")]
        public Memory Memory { get; set; }
    }
}
