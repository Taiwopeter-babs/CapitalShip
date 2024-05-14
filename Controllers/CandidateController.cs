using CapitalShip.Dtos;
using CapitalShip.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CapitalShip.Controllers;

[ApiController]
[Route("api/v1/candidates")]
public sealed class CandidateController : ControllerBase
{
    private readonly IServiceManager _service;

    public CandidateController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{id}", Name = "GetCandidate")]
    public async Task<IActionResult> GetCandidate(string id)
    {
        var candidate = await _service.CandidateService.GetCandidateAsync(id);

        return Ok(candidate);
    }


    [HttpGet]
    public async Task<IActionResult> GetManyCandidates()
    {
        var candidates = await _service.CandidateService.GetManyCandidatesAsync();

        return Ok(candidates);
    }


    [HttpPost]
    public async Task<IActionResult> AddCandidate([FromBody] CandidateCreateDto candidate)
    {

        var addedCandidate = await _service.CandidateService.AddCandidateAsync(candidate);

        return CreatedAtRoute("GetCandidate", new { addedCandidate.Id }, addedCandidate);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCandidate(string id)
    {
        await _service.CandidateService.DeleteCandidateAsync(id);

        return NoContent();
    }
}