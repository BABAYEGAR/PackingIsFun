﻿using System.ComponentModel.DataAnnotations;

namespace Pif.Models.Entities
{
    public class AccountModel
    {
        [Required]
        [Display(Name = "Email/Username")]
        public string LoginName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
        public long? ClientId { get; set; }
        public long? RoleId { get; set; }
        public string LoginType { get; set; }
        public string ProfilePicture { get; set; }
    }
}
