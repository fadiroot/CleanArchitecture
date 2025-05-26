namespace Microsoft.Extensions.DependencyInjection.Levels.Commands.CreateLevel
{
    public class CreateLevelCommandValidator : AbstractValidator<CreateLevelCommand> 
    {
        public CreateLevelCommandValidator()
        {
            RuleFor(l => l.Name).MaximumLength(100)
                .NotEmpty();
        }
    
    }
}
