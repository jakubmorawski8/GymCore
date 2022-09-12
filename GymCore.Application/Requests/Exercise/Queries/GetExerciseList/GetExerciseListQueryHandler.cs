using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using GymCore.Application.Exceptions;
using GymCore.Application.Interfaces.Persistence;
using GymCore.Domain.Entities;
using MediatR;

namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExerciseListQueryHandler : IRequestHandler<GetExerciseListQuery, List<ExerciseListVm>>
    {
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public GetExerciseListQueryHandler(IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }
        
        public async Task<GetExerciseListResponse> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
        {
            IQueryable<ExerciseEntity> query;
            var sortDirection = request.SortDirection == "desc" ? true : false;

            switch(request.SortField)
            {
                case "CreatedDate":
                    query = _exerciseRepository.GetAll(x => x.CreatedDate, sortDirection);
                    break;
                case "ModifiedDate":
                    query = _exerciseRepository.GetAll(x => x.ModifiedDate, sortDirection);
                    break;
                case "Name":
                    query = _exerciseRepository.GetAll(x => x.Name, sortDirection);
                    break;
                case "Description":
                    query = _exerciseRepository.GetAll(x => x.Description, sortDirection);
                    break;
                default:
                    throw new BadRequestException(String.Format("Field {0} doesn't exist"));
                
            }

            var entities = await _exerciseRepository.GetPagedResponseAsync(query, request.Page, request.Size);
            var response = new GetExerciseListResponse();
            response.exercises = _mapper.Map<List<ExerciseListVm>>(entities);
            return response;                
        }
    }
}
