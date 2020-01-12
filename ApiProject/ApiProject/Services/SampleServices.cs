using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiProject.Models;

namespace ApiProject.Services
{
    

    public class SampleServices : ISampleServices
    {
        private readonly ConcurrentDictionary<Guid, Details> _details = new ConcurrentDictionary<Guid, Details>();

        public Task AddAsync(Details detail)
        {
            detail.Id = Guid.NewGuid();
            _details[detail.Id] = detail;
            return Task.CompletedTask;
        }

        public Task AddRangeAsync(IEnumerable<Details> details)
        {
            foreach (var detail in details)
            {
                detail.Id = Guid.NewGuid();
                _details[detail.Id] = detail;
            }
            return Task.CompletedTask;
        }

        public Task<Details> RemoveAsync(Guid id)
        {
            _details.TryRemove(id, out Details removed);
            return Task.FromResult(removed);
        }

        public Task<IEnumerable<Details>> GetAllAsync() => Task.FromResult<IEnumerable<Details>>(_details.Values);

        public Task<Details> FindAsync(Guid id)
        {
            _details.TryGetValue(id, out Details detail);
            return Task.FromResult(detail);
        }


        public Task UpdateAsync(Details detail)
        {
            _details[detail.Id] = detail;
            return Task.CompletedTask;
        }

       
    }
}
