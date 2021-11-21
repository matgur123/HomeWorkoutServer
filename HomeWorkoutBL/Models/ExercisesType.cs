using System;
using System.Collections.Generic;

#nullable disable

namespace HomeWorkoutBL.Models
{
    public partial class ExercisesType
    {
        public ExercisesType()
        {
            Exercises = new HashSet<Exercise>();
        }

        public int ExercisesTypeId { get; set; }
        public string ExercisetypeDes { get; set; }

        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
