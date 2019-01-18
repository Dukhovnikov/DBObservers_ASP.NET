using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Observer_ASP.NET_Core.Models
{
    public sealed class MobileContext : DbContext
    {
        public DbSet<Phone> Phones { get; set; }
        public MobileContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }

    public class Phone
    {
        public int Id { get; set; }
        public string Name { get; set; } // название смартфона
        public string Company { get; set; } // компания
        public int Price { get; set; } // цена
    }
}
