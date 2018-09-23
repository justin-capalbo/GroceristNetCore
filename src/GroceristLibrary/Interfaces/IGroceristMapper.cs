using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.DB.Entities;
using GroceristLibrary.Models;

namespace GroceristLibrary.Interfaces
{
    public interface IGroceristMapper
    {
        UserList Map(UserListModel model);
        UserListItem Map(UserListItemModel model);
        UserListModel Map(UserList list);
        UserListItemModel Map(UserListItem item);
    }
}
