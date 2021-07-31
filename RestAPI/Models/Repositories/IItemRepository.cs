using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestAPI.Models.Repositories
{
    public interface IItemRepository
    {
        Task<IEnumerable<Item>> Get();
        Task<Item> Get(int id);
        Task<Item> Create(Item item);
        Task Update(Item item);
        Task Delete(int id);
    }
}
