using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElectronCalendar.Database.Entities
{
    public class UserEventInvite
    {
        [Key] public Guid Id { get; set; }
        [ForeignKey(nameof(InvitedUser))] public Guid InvitedUserId { get; set; }
        [ForeignKey(nameof(EventData))] public UserEvent UserEventId { get; set; }
        public bool ShowInCalendar { get; set; }
        public User InvitedUser { get; set; }
        public UserEvent EventData { get; set; }
    }
}