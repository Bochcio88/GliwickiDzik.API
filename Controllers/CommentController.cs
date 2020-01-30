using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GliwickiDzik.API.Data;
using GliwickiDzik.API.DTOs;
using GliwickiDzik.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using GliwickiDzik.API.Helpers;

namespace GliwickiDzik.API.Controllers
{
    //http://localhost:5000/api/userid/content
    [Route("api/{userId}/[controller]")]
    [ApiController]
    [Authorize]
    [ServiceFilter(typeof(ActionFilter))]
    public class ContentController : ControllerBase
    {
        private readonly IContentRepository _repository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public ContentController(IContentRepository repository, IUserRepository userRepository, IMapper mapper)
        {
            _repository = repository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

       

        #region = "COMMENTS"

        [HttpGet("GetComment/{commentId}")]
        public async Task<IActionResult> GetCommentAsync(int commentId)
        {
            var comment = await _repository.GetCommentAsync(commentId);

            if (comment == null)
                return BadRequest("Error: The comment cannot be found!");
            
            var commentToReturn = _mapper.Map<CommentForReturnDTO>(comment);

            return Ok(commentToReturn);
        }

        [HttpGet("GetComments/{trainingPlanId}")]
        public async Task<IActionResult> GetCommentsForTrainingPlanAsync(int trainingPlanId, [FromQuery]CommentParams commentParams)
        {
            var commentsToList = await _repository.GetAllCommentsAsync(trainingPlanId, commentParams);

            if (commentsToList == null)
                return BadRequest("Error: Comments cannot be found!");
            
            var commentsToReturn = _mapper.Map<IEnumerable<CommentForReturnDTO>>(commentsToList);

            Response.AddPagination(commentsToList.CurrentPage, commentsToList.PageSize, commentsToList.TotalCount, commentsToList.TotalPages);

            return Ok(commentsToReturn);
        }

        [HttpPost("AddComment/{planId}")]
        public async Task<IActionResult> AddCommentAsync(int userId, int trainingPlanId, CommentForCreateDTO commentForCreateDTO)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var trainingPlan = await _repository.GetCommentAsync(trainingPlanId);

            if (trainingPlan == null)
                return BadRequest("Error: The training plan cannot be found!");
            
            var comment = _mapper.Map<CommentModel>(commentForCreateDTO);
            comment.CommenterId = userId;
            comment.TrainingPlanId = trainingPlanId;

            _repository.Add(comment);

            if (!await _repository.SaveContentAsync())
                throw new Exception("Error: Saving comment to database failed!");
            
            return NoContent();
        }

        [HttpPut("EditComment/{commentId}")]
        public async Task<IActionResult> EditCommentAsync(int userId, int commentId, CommentForEditDTO commentForEditDTO)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var commentToEdit = await _repository.GetCommentAsync(commentId);

            if ( commentToEdit == null)
                return BadRequest("The comment cannot be found!");
            
            var editedComment = _mapper.Map(commentToEdit, commentForEditDTO);

            if (!await _repository.SaveContentAsync())
                throw new Exception("Error: Saving edited comment to database failed!");
            
            return NoContent();
        }

        [HttpDelete("RemoveComment/{commentId}")]
        public async Task<IActionResult> RemoveCommentAsync(int userId, int commentId)
        {
            if (userId != int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value))
                return Unauthorized();
            
            var commentToDelete = await _repository.GetCommentAsync(commentId);

            if (commentToDelete == null)
                return BadRequest("The comment cannnot be found!");
            
            if (userId != commentToDelete.CommenterId)
                return Unauthorized();

            _repository.Remove(commentToDelete);

            if (await _repository.SaveContentAsync())
                return NoContent();

            throw new Exception("Error: Removing comment from database failed!");   
        }
        
        #endregion
    }
}