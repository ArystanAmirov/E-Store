using E_Store.Data.Base;
using E_Store.Data.ViewModels;
using E_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Store.Data.Services
{
    public interface IPhonesService:IEntityBaseRepository<Phone>
    {
        Task<Phone> GetPhoneByIdAsync(int id);
        Task<NewPhoneDropdownsVM> GetNewPhoneDropdownsValues();
        Task AddNewPhoneAsync(NewPhoneVM data);
        Task UpdatePhoneAsync(NewPhoneVM data);
    }
}
