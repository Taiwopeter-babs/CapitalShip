using System.Globalization;
using CapitalShip.Dtos;
using CapitalShip.Models;
using FluentValidation;

namespace CapitalShip.Validators;

public class CandidateValidator : AbstractValidator<CandidateCreateDto>
{
    public CandidateValidator()
    {
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.Email).NotEmpty().EmailAddress();
        RuleFor(c => c.Phone).NotEmpty();
        RuleFor(c => c.Nationality).NotEmpty();
        RuleFor(c => c.CurrentResidence).NotEmpty();
        RuleFor(c => c.IdNumber).NotEmpty().GreaterThan(0);
        RuleFor(c => c.Birthday).NotEmpty();
        RuleFor(c => c.Gender).NotEmpty().IsEnumName(typeof(GenderType), caseSensitive: false);

        // Validate questions
        RuleFor(c => c.Answers).NotEmpty();
        RuleForEach(c => c.Answers).ChildRules(answer =>
        {
            answer.RuleFor(q => q.QuestionType).IsEnumName(typeof(QuestionType), caseSensitive: false);
            answer.RuleFor(q => q.QuestionTitle).NotEmpty();
            answer.RuleFor(q => q.QuestionAnswer).NotEmpty();
        });
    }

    // private static bool IsValidDate(string? dateString)
    // {
    //     if (dateString is null)
    //         return true;

    //     DateTime datetimeUtc;

    //     datetimeUtc = DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);

    //     datetimeUtc = DateTime.SpecifyKind(datetimeUtc, DateTimeKind.Utc);


    //     try
    //     {
    //         datetimeUtc = DateTime.SpecifyKind(datetimeUtc, DateTimeKind.Utc);
    //     }
    //     catch (FormatException)
    //     {
    //         return false;
    //     }

    //     bool isParsed = DateTime.TryParse(dateString, out DateTime dateTime);

    //     return isParsed;
    // }
}