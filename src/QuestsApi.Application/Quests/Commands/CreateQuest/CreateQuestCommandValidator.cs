using FluentValidation;

namespace QuestsApi.Application.Quests.Commands.CreateQuest;

public class CreateQuestCommandValidator : AbstractValidator<CreateQuestCommand>
{
    public CreateQuestCommandValidator()
    {
        RuleFor(c => c.Title).NotEmpty();
        RuleFor(c => c.Description).NotEmpty();
        RuleFor(c => c.CompleteConditions).NotEmpty();
        RuleFor(c => c.Rewards).NotEmpty();
    }
}