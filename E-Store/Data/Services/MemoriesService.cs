using E_Store.Data.Base;
using E_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data.Services
{
    public class MemoriesService: EntityBaseRepository<Memory>, IMemoriesService
    {
        public MemoriesService(AppDbContext context) : base(context)
        {
        }
    }
}
