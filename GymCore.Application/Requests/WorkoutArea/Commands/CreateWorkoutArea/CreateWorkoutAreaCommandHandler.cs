using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.WorkoutArea.Commands.CreateWorkoutArea
{
    public class CreateWorkoutAreaCommandHandler : IRequestHandler<CreateWorkoutAreaCommand, Guid>
    {
        private readonly IWorkoutAreaRepository _workoutAreaRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutAreaCommandHandler(IWorkoutAreaRepository workoutAreaRepository, IMapper mapper)
        {
            _workoutAreaRepository = workoutAreaRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateWorkoutAreaCommand request, CancellationToken cancellationToken)
        {
            var workoutArea = _mapper.Map<WorkoutAreaEntity>(request);
            workoutArea = await _workoutAreaRepository.AddAsync(workoutArea);

            return workoutArea.Id;
        }
    }
}
