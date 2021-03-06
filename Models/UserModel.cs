using System.Collections.Generic;
using System;
using GliwickiDzik.API.Models;
using System.ComponentModel.DataAnnotations;

namespace GliwickiDzik.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        //For Register
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }

        //For Information
        public DateTime DateOfCreated { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Growth  { get; set; }
        public float Weight { get; set; }
        public string Description { get; set; }
        public float BicepsSize { get; set; }
        public ICollection<PhotoModel> Photos { get; set; }
        public ICollection<PlanModel> TrainingPlans { get; set; }
        public ICollection<MessageModel> MessagesSent { get; set; }
        public ICollection<MessageModel> MessagesReceived { get; set; }
        public ICollection<LikeModel> UserLikes { get; set; }
        public ICollection<LikeModel> PlanIsLiked { get; set; }
    }
}