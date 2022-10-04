using FluentValidation;


namespace GymCore.Application.Requests.Exercise.Queries.GetExerciseList
{
    public class GetExerciseListQueryValidator : AbstractValidator<GetExerciseListQuery>
    {
        public GetExerciseListQueryValidator()
        {
            RuleFor(p => p.SortField)
                .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
                .Must(FieldNameIsSupported)
                .WithMessage("{SortFieldName} is not supported");
        }


        private bool FieldNameIsSupported(string fieldName)
        {
            switch (fieldName)
            {
                case "CreatedDate":
                case "ModifiedDate":
                case "Name":
                case "Description":
                    return true;
                default:
                    return false;
            }
        }
    }
}

