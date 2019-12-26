using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GliwickiDzik.API.Models
{
    public class ExerciseForTrainingModel
    {
        [Key]
        public int ExerciseForTrainingId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public TrainingModel Training { get; set; }
        public int TrainingId { get; set; }
    }
}