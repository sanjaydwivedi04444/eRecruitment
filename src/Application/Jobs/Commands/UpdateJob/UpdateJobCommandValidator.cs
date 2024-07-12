namespace eRecruitment.Application.Jobs.Commands.UpdateJob;
public class UpdateJobCommandValidator : AbstractValidator<UpdateJobCommand>
{
    public UpdateJobCommandValidator()
    {
        RuleFor(v => v.Title)
            .MaximumLength(200)
            .NotEmpty();
    }
}
