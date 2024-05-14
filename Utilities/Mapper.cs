using AutoMapper;
using CapitalShip.Dtos;
using CapitalShip.Models;


namespace BookARoom.Utilities;

public class MappingProfile : Profile
{
    public MappingProfile()
    {

        // CreateMap<ProgrammeCreateDto, Programme>();
        // CreateMap<Programme, ProgrammeDto>();

        CreateMap<QuestionCreateDto, Question>();
        CreateMap<Question, QuestionDto>().ReverseMap();
        // CreateMap<QuestionDto, Question>();
        CreateMap<QuestionUpdateDto, Question>();

        CreateMap<CandidateCreateDto, Candidate>();
        CreateMap<Candidate, CandidateDto>().ReverseMap();
        // CreateMap<CandidateDto, Candidate>();

        CreateMap<AnswerDto, Answer>().ReverseMap();

    }


}