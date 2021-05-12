using AutoMapper;
using GymCore.Application.Requests.Exercise.Commands.CreateExercise;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails;
using GymCore.Application.Requests.Exercise.Queries.GetExerciseList;
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
            #region Workout
            CreateMap<WorkoutEntity, WorkoutListVm>().ReverseMap();
            CreateMap<WorkoutEntity, WorkoutDetailsVm>().ReverseMap();
            CreateMap<UserEntity, WorkoutUserDto>().ReverseMap();
            CreateMap<CreateWorkoutCommand, WorkoutEntity>().ReverseMap()
                .ForMember(dest => dest.CreatedBy,
                            opt => opt.MapFrom(src => src.CreatedBy));
            CreateMap<UpdateWorkoutCommand, WorkoutEntity>().ReverseMap();
            #endregion Workout

            #region Exercise
            CreateMap<ExerciseDetailsVm, ExerciseEntity>().ReverseMap();
            CreateMap<CreateExerciseCommand, ExerciseEntity>().ReverseMap();
            CreateMap<UpdateWorkoutCommand, ExerciseEntity>().ReverseMap();
            CreateMap<ExerciseEntity, ExerciseListVm>().ReverseMap();
            #endregion Exercise
        }
    }
}
