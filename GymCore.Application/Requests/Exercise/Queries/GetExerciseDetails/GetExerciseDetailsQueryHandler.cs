using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails
{
    public class GetExerciseDetailsQueryHandler : IRequestHandler<GetExerciseDetailsQuery, ExerciseDetailsVm>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExerciseDetailsQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<ExerciseDetailsVm> Handle(GetExerciseDetailsQuery request, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);
            var exerciseDetailDto = _mapper.Map<ExerciseDetailsVm>(exercise);
            return exerciseDetailDto;
        }
    }
}
