using System.Collections.Generic;

namespace GroceristLibrary.DB.Entities
{
    public class UserList
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserListItem> Items { get; set; }
    }
}
