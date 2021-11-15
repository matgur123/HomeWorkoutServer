using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace HomeWorkoutBL.Models
{
    [Table("ExercisesType")]
    public partial class ExercisesType
    {
        public ExercisesType()
        {
            Exercises = new HashSet<Exercise>();
        }

        [Key]
        [Column("ExercisesTypeID")]
        public int ExercisesTypeId { get; set; }
        [Required]
        [StringLength(255)]
        public string ExercisetypeDes { get; set; }

        [InverseProperty(nameof(Exercise.ExercisesTypeNavigation))]
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
