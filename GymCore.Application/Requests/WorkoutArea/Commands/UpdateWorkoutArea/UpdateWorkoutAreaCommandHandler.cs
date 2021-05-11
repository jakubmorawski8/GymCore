using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.UpdateWorkoutArea
{
    public class UpdateWorkoutAreaCommandHandler : IRequestHandler<UpdateWorkoutAreaCommand, Unit>
    {
        private readonly IWorkoutAreaRepository _workoutAreaRepository;
        private readonly IMapper _mapper;

        public UpdateWorkoutAreaCommandHandler(IWorkoutAreaRepository workoutAreaRepository, IMapper mapper)
        {
            _workoutAreaRepository = workoutAreaRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateWorkoutAreaCommand request, CancellationToken cancellationToken)
        {
            var workoutAreaToUpdate = await _workoutAreaRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, workoutAreaToUpdate);
            await _workoutAreaRepository.UpdateAsync(workoutAreaToUpdate);

            return Unit.Value;
        }
    }
}
