using AutoMapper;
using GymCore.Application.Requests.UserWorkout.Commands.CreateUserWorkout;
using GymCore.Application.Requests.Workout.Commands.CreateWorkout;
using GymCore.Application.Requests.Workout.Commands.UpdateWorkout;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutDetails;
using GymCore.Application.Requests.Workout.Queries.GetWorkoutsList;
using GymCore.Application.Requests.WorkoutArea.Commands.CreateWorkoutArea;
using GymCore.Application.Requests.WorkoutArea.Commands.UpdateWorkoutArea;
using GymCore.Application.Requests.WorkoutAreaExercise.Commands.CreateWorkoutAreaExercise;
using GymCore.Application.Requests.WorkoutAreaExercise.Commands.UpdateWorkoutAreaExercise;
using GymCore.Application.Requests.WorkoutAreaExercise.Queries;
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
                .ForMember(dest => dest.CreatedBy,
                            opt => opt.MapFrom(src => src.CreatedBy));
            CreateMap<UpdateWorkoutCommand, WorkoutEntity>().ReverseMap();
            CreateMap<CreateUserWorkoutCommand, UserWorkoutEntity>().ReverseMap();
            CreateMap<CreateWorkoutAreaCommand, WorkoutAreaEntity>().ReverseMap();
            CreateMap<UpdateWorkoutAreaCommand, WorkoutAreaEntity>().ReverseMap();
            CreateMap<CreateWorkoutAreaExerciseCommand, WorkoutAreaExerciseEntity>().ReverseMap();
            CreateMap<UpdateWorkoutAreaExerciseCommand, WorkoutAreaExerciseEntity>().ReverseMap();
            CreateMap<WorkoutAreaExerciseEntity, WorkoutAreaExerciseVm>().ReverseMap();
        }
    }
}
