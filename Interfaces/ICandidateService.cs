using CapitalShip.Dtos;
using CapitalShip.Utilities;

namespace CapitalShip.Interfaces;

public interface ICandidateService
{
    Task<CandidateDto> AddCandidateAsync(CandidateCreateDto candidate);
    // Task UpdateCandidateAsync(string CandidateId, CandidateUpdateDto Candidate);

    Task<CandidateDto> GetCandidateAsync(string candidateId);

    Task<IEnumerable<CandidateDto>> GetManyCandidatesAsync();
    Task DeleteCandidateAsync(string candidateId);
}