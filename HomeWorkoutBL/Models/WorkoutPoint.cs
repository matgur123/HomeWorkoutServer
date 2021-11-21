using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class WorkoutPoint
    {
        public int WorkoutPointsId { get; set; }
        public int PointsId { get; set; }
        public int DateAndTime { get; set; }
        public int PointsGathered { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
