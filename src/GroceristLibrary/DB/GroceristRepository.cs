using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.DB.Entities;
using Microsoft.EntityFrameworkCore;

namespace GroceristLibrary.DB
{
    public class GroceristRepository : IGroceristRepository
    {
        private readonly GroceristContext _ctx;

        public GroceristRepository(GroceristContext ctx)
        {
            _ctx = ctx;
        }

        public async Task AddListAsync(UserList list)
        {
            await _ctx.UserList.AddAsync(list);
        }

        public async Task<IEnumerable<UserList>> GetReadOnlyListsUnfilteredAsync()
        {
            return await _ctx.UserList
                .AsNoTracking()
                .Include(l => l.Items)
                .ToListAsync();
        }

        public async Task<UserList> GetLiveUserListByNameAsync(string name)
        {
            return await _ctx.UserList
                .Include(l => l.Items)
                .FirstOrDefaultAsync(l => l.Name.Equals(name.ToLowerInvariant()));
        }

        public async Task<UserList> GetReadOnlyUserListByNameAsync(string name)
        {
            return await _ctx.UserList
                .AsNoTracking()
                .Include(l => l.Items)
                .FirstOrDefaultAsync(l => l.Name.Equals(name.ToLowerInvariant()));
        }

        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}
