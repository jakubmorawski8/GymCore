using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Commands.CreateUserWorkout
{
    public class CreateUserWorkoutCommandHandler : IRequestHandler<CreateUserWorkoutCommand, Guid>
    {
        private readonly IUserWorkoutRepository _userWorkoutRepository;
        private readonly IMapper _mapper;
        public CreateUserWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository, IMapper mapper)
        {
            _userWorkoutRepository = userWorkoutRepository;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateUserWorkoutCommand request, CancellationToken cancellationToken)
        {
            var userWorkout = _mapper.Map<UserWorkoutEntity>(request);
            userWorkout = await _userWorkoutRepository.AddAsync(userWorkout);
            return userWorkout.Id;
        }
    }
}
