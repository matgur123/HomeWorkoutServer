using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class WorkoutPoint
    {
        [Key]
        [Column("PointsUserID")]
        public int PointsUserId { get; set; }
        [Column("pointsID")]
        public int PointsId { get; set; }
        [Column("dateAndTime")]
        public int DateAndTime { get; set; }
        [Column("pointsGathered")]
        public int PointsGathered { get; set; }
    }
}
