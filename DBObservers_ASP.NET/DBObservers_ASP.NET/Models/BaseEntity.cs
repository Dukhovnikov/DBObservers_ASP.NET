using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBObservers_ASP.NET.Models
{
    public abstract class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
    }
}
