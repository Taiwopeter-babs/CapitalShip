using CapitalShip.Dtos;
using CapitalShip.Models;
using FluentValidation;

public class ProgrammeValidator : AbstractValidator<ProgrammeCreateDto>
{
    public ProgrammeValidator()
    {
        RuleFor(p => p.FirstName).NotEmpty();
        RuleFor(p => p.LastName).NotEmpty();
        RuleFor(p => p.Email).NotEmpty();
        RuleFor(p => p.Phone).NotEmpty();
        RuleFor(p => p.Nationality).NotEmpty();
        RuleFor(p => p.CurrentResidence).NotEmpty();
        RuleFor(p => p.IdNumber).NotEmpty().GreaterThan(0);
        RuleFor(p => p.Birthday).NotEmpty();
        RuleFor(p => p.Gender).NotEmpty().IsEnumName(typeof(GenderType), caseSensitive: false);

        // Validate questions
        RuleFor(p => p.Questions).NotEmpty();
        RuleForEach(p => p.Questions).ChildRules(question =>
        {
            question.RuleFor(q => q.QuestionType).IsEnumName(typeof(QuestionType), caseSensitive: false);
            question.RuleFor(q => q.QuestionTitle).NotEmpty();
        });
    }
}