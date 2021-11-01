using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Username { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfilePic { get; set; }
        public int BirthDate { get; set; }
        public string UserAddress { get; set; }

        public virtual Tournament Tournament { get; set; }
    }
}
