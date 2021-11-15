using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    [Index(nameof(Email), Name = "UQ__Users__AB6E6164EDD86FFC", IsUnique = true)]
    [Index(nameof(Username), Name = "UQ__Users__F3DBC572EAE082EB", IsUnique = true)]
    public partial class User
    {
        [Key]
        [Column("userID")]
        public int UserId { get; set; }
        [Required]
        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [Column("pass")]
        [StringLength(255)]
        public string Pass { get; set; }
        [Required]
        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; }
        [Column("isAdmin")]
        public bool IsAdmin { get; set; }
        [Required]
        [Column("profilePic")]
        [StringLength(255)]
        public string ProfilePic { get; set; }
        [Column("birthDate")]
        public int BirthDate { get; set; }
        [Column("userAddress")]
        [StringLength(255)]
        public string UserAddress { get; set; }

        [InverseProperty("Admin")]
        public virtual Tournament Tournament { get; set; }
    }
}
