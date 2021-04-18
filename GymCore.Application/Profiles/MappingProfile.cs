using AutoMapper;
using GymCore.Application.Requests.Workout.Commands.CreateWorkout;
using GymCore.Application.Requests.Workout.Commands.UpdateWorkout;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using GymCore.Domain.Entities;

namespace GymCore.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<WorkoutEntity, WorkoutListVm>().ReverseMap();
            CreateMap<WorkoutEntity, WorkoutDetailsVm>().ReverseMap();
            CreateMap<UserEntity, WorkoutUserDto>().ReverseMap();
            CreateMap<CreateWorkoutCommand, WorkoutEntity>().ReverseMap()
                .ForMember(dest => dest.Owner,
                            opt => opt.MapFrom(src => src.CreatedBy));
            CreateMap<UpdateWorkoutCommand, WorkoutEntity>().ReverseMap();
        }
    }
}
