using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.DB;
using GroceristLibrary.DB.Entities;
using GroceristLibrary.Interfaces;
using GroceristLibrary.Models;
using Microsoft.Extensions.Logging;

namespace GroceristLibrary.ApplicationLogic
{
    public class ListApplicationLogic : IListApplicationLogic
    {
        private readonly ILogger<ListApplicationLogic> _logger;
        private readonly IGroceristRepository _repo;
        private readonly IGroceristMapper _mapper;

        public ListApplicationLogic(ILogger<ListApplicationLogic> logger, 
            IGroceristRepository repo, 
            IGroceristMapper mapper)
        {
            _logger = logger;
            _repo = repo;
            _mapper = mapper;
        }

        public async Task AddNewUserListAsync(UserListModel userList)
        {
            await _repo.AddListAsync(_mapper.Map(userList));

            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Error saving userList.\n{e.Message}\n{e.StackTrace}");
            }
        }

        public async Task<IEnumerable<UserListModel>> GetAllUserListsAsync()
        {
            var lists = await _repo.GetReadOnlyListsUnfilteredAsync();
            return lists.Select(_mapper.Map);
        }
    }
}
