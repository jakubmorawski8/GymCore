using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.WorkoutAreaExercise.Commands.CreateWorkoutAreaExercise
{
    public class CreateWorkoutAreaExerciseCommandHandler : IRequestHandler<CreateWorkoutAreaExerciseCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IWorkoutAreaExerciseRepository _workoutAreaExerciseRepository;

        public CreateWorkoutAreaExerciseCommandHandler(IMapper mapper, IWorkoutAreaExerciseRepository workoutAreaExerciseRepository)
        {
            _mapper = mapper;
            _workoutAreaExerciseRepository = workoutAreaExerciseRepository;
        }

        public async Task<Guid> Handle(CreateWorkoutAreaExerciseCommand request, CancellationToken cancellationToken)
        {
            var workoutAreaExercise = _mapper.Map<WorkoutAreaExerciseEntity>(request);
            workoutAreaExercise = await _workoutAreaExerciseRepository.AddAsync(workoutAreaExercise);

            return workoutAreaExercise.Id;
        }
    }
}
