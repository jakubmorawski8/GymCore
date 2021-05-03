using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.Workout.Commands.CreateWorkout
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, Guid>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;
        public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            var workout = _mapper.Map<WorkoutEntity>(request);
            workout = await _workoutRepository.AddAsync(workout);
            return workout.Id;
        }
    }
}
