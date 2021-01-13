using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ElectronCalendar.Database.Enums;

namespace ElectronCalendar.Database.Entities
{
    public class UserEvent
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(User))] public Guid UserId { get; set; }

        [MaxLength(100)] public string EventName { get; set; }
        [MaxLength(255)] public string Description { get; set; }

        public DateTime ScheduledDate { get; set; }

        public EventType EventType { get; set; }

        public User User { get; set; }

        public ICollection<UserEventInvite> InvitedUsers { get; set; }
    }
}