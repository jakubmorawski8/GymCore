using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Commands.UpdateExercise
{
    public class UpdateExerciseCommandHandler : IRequestHandler<UpdateExerciseCommand>
    {
        public IExerciseRepository _exerciseRepository { get; set; }
        public IMapper _mapper { get; set; }

        public UpdateExerciseCommandHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = _exerciseRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateExerciseCommand request, CancellationToken cancellationToken)
        {
            var exerciseToUpdate = await _exerciseRepository.GetByIdAsync(request.Id);
            _mapper.Map(request, exerciseToUpdate, typeof(UpdateExerciseCommand), typeof(ExerciseEntity));
            await _exerciseRepository.UpdateAsync(exerciseToUpdate);
            return Unit.Value;
        }
    }
}
