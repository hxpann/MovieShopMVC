﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }

        [MaxLength(128)]
        public string? FirstName { get; set; }

        [MaxLength(128)]
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }

        [MaxLength(256)]
        public string? Email { get; set; }

        [MaxLength(1024)]
        public string? HashedPassword { get; set; }

        [MaxLength(1024)]
        public string? Salt { get; set; }

        [MaxLength(16)]
        public string? PhoneNumber { get; set; }
        public bool? TwoFactorEnabled { get; set; }
        public DateTime? LockOutEndDate { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public bool? IsLocked { get; set; }
        public int? AccessFailedCount { get; set; }

        //Navigation property
        public ICollection<Review> UsersReviews {get; set; }

        public ICollection<Purchase> UsersOfPurchase { get; set; }
        public ICollection<Favorite> UsersOfFavorite { get; set; }
        public ICollection<UserRole> UsersOfRole { get; set; }

    }
}
