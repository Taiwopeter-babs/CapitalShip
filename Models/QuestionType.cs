namespace CapitalShip.Models;

/// <summary>
/// Enum for validating the QuestionType property of the Question model DTO
/// </summary>
public enum QuestionType
{
    Paragraph,
    YesNo,
    Dropdown,
    MultipleChoice,
    Date,
    Number
}