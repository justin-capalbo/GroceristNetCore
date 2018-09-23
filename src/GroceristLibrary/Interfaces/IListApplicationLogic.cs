using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.Models;

namespace GroceristLibrary.Interfaces
{
    public interface IListApplicationLogic
    {
        Task AddNewUserListAsync(UserListModel userList);
        Task<IEnumerable<UserListModel>> GetAllUserListsAsync();
    }
}
