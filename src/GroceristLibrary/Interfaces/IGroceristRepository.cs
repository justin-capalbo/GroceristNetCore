using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.DB.Entities;

namespace GroceristLibrary.DB
{
    public interface IGroceristRepository
    {
        Task AddListAsync(UserList list);
        Task<IEnumerable<UserList>> GetReadOnlyListsUnfilteredAsync();
        Task<UserList> GetLiveUserListByNameAsync(string name);
        Task<UserList> GetReadOnlyUserListByNameAsync(string name);
        Task SaveChangesAsync();
    }
}
