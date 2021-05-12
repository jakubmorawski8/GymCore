using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.UpdateWorkoutAreaExercise
{
    public class UpdateWorkoutAreaExerciseCommandHandler : IRequestHandler<UpdateWorkoutAreaExerciseCommand>
    {
        private readonly IMapper _mapper;
        private readonly IWorkoutAreaExerciseRepository _workoutAreaExerciseRepository;

        public UpdateWorkoutAreaExerciseCommandHandler(IMapper mapper, IWorkoutAreaExerciseRepository workoutAreaExerciseRepository)
        {
            _mapper = mapper;
            _workoutAreaExerciseRepository = workoutAreaExerciseRepository;
        }

        public async Task<Unit> Handle(UpdateWorkoutAreaExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutAreaExercise = await _workoutAreaExerciseRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, workoutAreaExercise);
            await _workoutAreaExerciseRepository.UpdateAsync(workoutAreaExercise);

            return Unit.Value;
        }
    }
}
