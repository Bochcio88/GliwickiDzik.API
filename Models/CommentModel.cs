using System.Collections.Generic;
using System;
using GliwickiDzik.Models;

namespace GliwickiDzik.API.Models
{
    public class CommentModel
    {
        public int CommentId { get; set; }
        public int CommenterId { get; set; }
        public UserModel Commenter { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreated { get; set; }
        public bool CommentDeleted { get; set; }
        public TrainingPlanModel TrainingPlan { get; set; }
        public int TrainingPlanId { get; set; }
        public int LikeCounter { get; set; }
        public ICollection<LikeModel> Likes { get; set; }
    }
}