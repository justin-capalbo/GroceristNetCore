using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroceristLibrary.DB.Entities;
using GroceristLibrary.Interfaces;
using GroceristLibrary.Models;

namespace GroceristLibrary.ApplicationLogic
{
    public class GroceristMapper : IGroceristMapper
    {
        public UserList Map(UserListModel model)
        {
            return new UserList
            {
                Name = model.Name,
                Items = model.Items?.Select(Map).ToList()
            };
        }

        public UserListItem Map(UserListItemModel model)
        {
            return new UserListItem
            {
                Name = model.Name,
                Notes = model.Notes
            };
        }

        public UserListModel Map(UserList list)
        {
            return new UserListModel
            {
                Name = list.Name,
                Items = list.Items?.Select(Map).ToList()
            };
        }

        public UserListItemModel Map(UserListItem item)
        {
            return new UserListItemModel
            {
                Name = item.Name,
                Notes = item.Notes
            };
        }
    }
}
