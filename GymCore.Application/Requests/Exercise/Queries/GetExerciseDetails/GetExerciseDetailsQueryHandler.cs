using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseDetails
{
    public class GetExerciseDetailsQueryHandler : IRequestHandler<GetExerciseDetailsQuery, GetExerciseDetailsQueryResponse>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExerciseDetailsQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<GetExerciseDetailsQueryResponse> Handle(GetExerciseDetailsQuery request, CancellationToken cancellationToken)
        {
            var response = new GetExerciseDetailsQueryResponse();
            var exercise = await _exerciseRepository.GetByIdAsync(request.Id);

            if (exercise is null)
                response.Success = false;

            var exerciseDetailDto = _mapper.Map<ExerciseDetailsVm>(exercise);
            response.ExerciseDetailsVm = exerciseDetailDto;

            return response;
        }
    }
}
