using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronCalendar.Database.Entities
{
    public class User
    {
        [Key] public Guid Id { get; set; }
        [MaxLength(120)] public string Name { get; set; }
        [MaxLength(100)] public string Password { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedOn { get; set; }
    }
}