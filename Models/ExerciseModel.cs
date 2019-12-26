using System.ComponentModel.DataAnnotations;

namespace GliwickiDzik.API.Models
{
    public class ExerciseModel
    {
        [Key]
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}