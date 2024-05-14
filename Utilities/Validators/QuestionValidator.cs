using CapitalShip.Dtos;
using CapitalShip.Models;
using FluentValidation;

namespace CapitalShip.Validators;

public class QuestionValidator : AbstractValidator<QuestionCreateDto>
{
    public QuestionValidator()
    {
        RuleFor(q => q.QuestionTitle).NotEmpty().MaximumLength(100);
        RuleFor(q => q.QuestionType).NotEmpty().IsEnumName(typeof(QuestionType), caseSensitive: false);
    }
}

public class QuestionUpdateValidator : AbstractValidator<QuestionUpdateDto>
{
    public QuestionUpdateValidator()
    {
        RuleFor(q => q.QuestionTitle).NotEmpty().MaximumLength(100);
        RuleFor(q => q.QuestionType).NotEmpty().IsEnumName(typeof(QuestionType), caseSensitive: false);
    }
}
