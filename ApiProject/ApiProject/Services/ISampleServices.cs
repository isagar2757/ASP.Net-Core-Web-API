using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Models;

namespace ApiProject.Services
{
    public interface ISampleServices
    {

        Task AddAsync(Details detail);
        Task AddRangeAsync(IEnumerable<Details> details);
        Task<Details> RemoveAsync(Guid id); //6-12

        Task<IEnumerable<Details>> GetAllAsync();
        Task<Details> FindAsync(Guid id);
        Task UpdateAsync(Details detail);
    }
}
