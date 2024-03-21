using E_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data.ViewModels
{
    public class NewPhoneDropdownsVM
    {
        public NewPhoneDropdownsVM()
        {
            Memories = new List<Memory>();
            CPUs = new List<CPU>();
        }

        public List<Memory> Memories { get; set; }
        public List<CPU> CPUs { get; set; }
    }
}
