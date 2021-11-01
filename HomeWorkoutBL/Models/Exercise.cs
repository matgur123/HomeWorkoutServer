using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class Exercise
    {
        public int ExercisesInfoId { get; set; }
        public int ExercisesType { get; set; }
        public int ExercisesDifficulty { get; set; }
        public string ExercisesDescri { get; set; }
        public string ExercisesName { get; set; }
        public string ExercisesVideo { get; set; }

        public virtual ExercisesDifficulty ExercisesDifficultyNavigation { get; set; }
        public virtual ExercisesType ExercisesTypeNavigation { get; set; }
    }
}
