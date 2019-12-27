using System;
using System.Collections.Generic;
using GliwickiDzik.API.Models;

namespace GliwickiDzik.API.DTOs
{
    public class TrainingPlanForReturnDTO
    {
        public int TrainingPlanId { get; set; }
        public int UserId { get; set; }
        public string Owner { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateOfCreated { get; set; }
        public string Level { get; set; }
        public bool IsMain { get; set; }
        public int LikeCounter { get; set; }
        public int CommentCounter { get; set; }
        public ICollection<CommentModel> Comments { get; set; }
        public ICollection<TrainingModel> Trainings { get; set; }
        public ICollection<LikeModel> PlanIsLiked { get; set; }
        public ICollection<LikeModel> UserLikes { get; set; }
    }
}