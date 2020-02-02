using AutoMapper;
using GliwickiDzik.API.DTOs;
using GliwickiDzik.API.DTOs.TrainingDTO;
using GliwickiDzik.API.Helpers.Params;
using GliwickiDzik.API.Models;
using GliwickiDzik.DTOs;
using GliwickiDzik.Models;

namespace GliwickiDzik.API.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //CreateMap<what you map, map to what>();

            CreateMap<UserForRegisterDTO, UserModel>();
            CreateMap<UserForEditDTO, UserModel>();
            CreateMap<UserModel, UserForReturnDTO>()
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
                });
            CreateMap<UserModel, UserForRecordsDTO>()
                .ForMember(dest => dest.Age, opt => {
                    opt.ResolveUsing(src => src.DateOfBirth.CalculateAge());
                });
            CreateMap<UserForRegisterDTO, UserForLoginDTO>();
            CreateMap<UserModel, UserToConvDTO>();
            
            CreateMap<ExerciseForCreateDTO, ExerciseModel>();
            CreateMap<ExerciseModel, ExerciseForReturnDTO>().ReverseMap();

            CreateMap<PlanForCreateDTO, PlanModel>();
            CreateMap<PlanModel, PlanForReturnDTO>();

            CreateMap<TrainingForCreateDTO, TrainingModel>();
            CreateMap<TrainingForEditDTO, TrainingModel>();
            CreateMap<TrainingModel, TrainingForReturnDTO>();

            CreateMap<PlanModel, PlanForReturnDTO>();
            CreateMap<PlanForEditDTO, PlanModel>();
            
            CreateMap<TrainingModel, TrainingForReturnDTO>();

            CreateMap<MessageForCreateDTO, MessageModel>().ReverseMap();
            CreateMap<MessageModel, MessageForReturnDTO>();

            CreateMap<CommentForReturnDTO, CommentModel>();
            CreateMap<CommentForEditDTO, CommentModel>();

            CreateMap<TrainingsForPlanforReturnDTO, TrainingsForPlan>();
        }
    }
}