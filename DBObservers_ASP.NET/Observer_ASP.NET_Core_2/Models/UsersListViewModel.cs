using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Observer_ASP.NET_Core_2.Models
{
    public class UsersListViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public SelectList Companies { get; set; }
        public string Name { get; set; }
    }
}
