using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Queries
{
    public class GetWorkoutAreaExerciseQueryHandler : IRequestHandler<GetWorkoutAreaExerciseQuery, WorkoutAreaExerciseVm>
    {
        private readonly IMapper _mapper;
        private readonly IWorkoutAreaExerciseRepository _workoutAreaExerciseRepository;

        public GetWorkoutAreaExerciseQueryHandler(IMapper mapper, IWorkoutAreaExerciseRepository workoutAreaExerciseRepository)
        {
            _mapper = mapper;
            _workoutAreaExerciseRepository = workoutAreaExerciseRepository;
        }

        public async Task<WorkoutAreaExerciseVm> Handle(GetWorkoutAreaExerciseQuery request, CancellationToken cancellationToken)
        {
            var workoutAreaExercise = await _workoutAreaExerciseRepository.GetWorkoutAreaExercise(request.WorkoutAreaId, request.ExerciseId);

            return _mapper.Map<WorkoutAreaExerciseVm>(workoutAreaExercise);
        }
    }
}
