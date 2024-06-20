using FluentValidation;
using LeagueManager.Application.Seasons;

namespace LeagueManager.League.WebApi.Validators;
internal class CreateSeasonValidator : AbstractValidator<CreateSeasonCommand>
{
    public CreateSeasonValidator()
    {
        RuleFor(x => x.StartDate)
            .NotNull()
            .WithMessage("Starting date cannot be null.");
    }
}
