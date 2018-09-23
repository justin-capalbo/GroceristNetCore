using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceristLibrary.Models
{
    public class UserListModel
    {
        public string Name { get; set; }
        public IList<UserListItemModel> Items { get; set; }
    }
}
