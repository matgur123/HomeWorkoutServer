using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class Workout
    {
        public int WorkoutId { get; set; }
        public string WorkoutName { get; set; }
        public int PointsForWorkout { get; set; }
        public string Descri { get; set; }
    }
}
