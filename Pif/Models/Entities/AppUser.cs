using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Pif.Models.Entities
{
    public class AppUser : Transport
    {
        public long AppUserId { get; set; }

        [MaxLength(100, ErrorMessage = "This field is does not support more than 100 characters")]
        [RegularExpression("[a-zA-Z ]*$")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "This field is does not support more than 100 characters")]
        [EmailAddress]
        public string Email { get; set; }

        [MaxLength(100, ErrorMessage = "This field is does not support more than 100 characters")]
        public string Mobile { get; set; }
        public string MobileExtension { get; set; }

        public string Address { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [Display(Name = "Role")]
        public long? RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }

        public string Status { get; set; }
        public string AccountType { get; set; }

        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; }

        public string BackgroundPicture { get; set; }
        public string Website { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Biography { get; set; }

        [Required]
        public string Username { get; set; }

        public bool HasSocialMediaLogin { get; set; }
        [JsonIgnore]
        public IEnumerable<AppUserAccessKey> AppUserAccessKeys { get; set; }
        [JsonIgnore]
        public IEnumerable<AccessLog> AccessLogs { get; set; }
        [JsonIgnore]
        public IEnumerable<PushNotification> PushNotifications { get; set; }
    }
}
