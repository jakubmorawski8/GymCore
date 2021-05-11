using System.Threading;
using System.Threading.Tasks;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.UserWorkout.Commands.DeleteUserWorkout
{
    public class DeleteUserWorkoutCommandHandler : IRequestHandler<DeleteUserWorkoutCommand>
    {
        private readonly IUserWorkoutRepository _userWorkoutRepository;
        public DeleteUserWorkoutCommandHandler(IUserWorkoutRepository userWorkoutRepository)
        {
            _userWorkoutRepository = userWorkoutRepository;
        }
        public async Task<Unit> Handle(DeleteUserWorkoutCommand request, CancellationToken cancellationToken)
        {
            var userWorkout = await _userWorkoutRepository.GetByIdAsync(request.Id);
            await _userWorkoutRepository.DeleteAsync(userWorkout);

            return Unit.Value;
        }
    }
}
