using CapitalShip.Dtos;
using CapitalShip.Interfaces;
using CapitalShip.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CapitalShip.Controllers;

[ApiController]
[Route("api/v1/questions")]
public sealed class QuestionController : ControllerBase
{
    private readonly IServiceManager _service;

    public QuestionController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{id}", Name = "GetQuestion")]
    public async Task<IActionResult> GetQuestion(string id)
    {
        var question = await _service.QuestionService.GetQuestionAsync(id);

        return Ok(question);
    }

    [HttpGet]
    public async Task<IActionResult> GetManyQuestions([FromQuery] QuestionParameters questionParams)
    {
        var questions = await _service.QuestionService.GetManyQuestionsAsync(questionParams);

        return Ok(questions);
    }

    [HttpPost]
    public async Task<IActionResult> AddQuestion([FromBody] QuestionCreateDto question)
    {

        var addedQuestion = await _service.QuestionService.AddQuestionAsync(question);

        return CreatedAtRoute("GetQuestion", new { addedQuestion.Id }, addedQuestion);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateQuestion(string id, [FromBody] QuestionUpdateDto question)
    {

        await _service.QuestionService.UpdateQuestionAsync(id, question);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteQuestion(string id)
    {
        await _service.QuestionService.DeleteQuestionAsync(id);

        return NoContent();
    }
}