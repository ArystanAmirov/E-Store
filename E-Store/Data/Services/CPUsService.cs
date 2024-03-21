using E_Store.Data.Base;
using E_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data.Services
{
    public class CPUsService:EntityBaseRepository<CPU>, ICPUsService
    {
        public CPUsService(AppDbContext context) : base(context)
        {
        }
    }
}
