using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Interfaces.Persistence;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExercisesListQueryHandler : IRequestHandler<GetExercisesListQuery, List<ExerciseListVm>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExercisesListQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        public async Task<List<ExerciseListVm>> Handle(GetExercisesListQuery request, CancellationToken cancellationToken)
        {
            var allExercises = (await _exerciseRepository.ListAllAsync()).OrderBy(x => x.CreatedDate);
            return _mapper.Map<List<ExerciseListVm>>(allExercises);
        }
    }
}
