using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries
{
    public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, ProgrammingLanguageGetByIdDto>
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
        private readonly ProgrammingLanguageRules _programmingLanguageRules;
        private readonly IMapper _mapper;

        public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, ProgrammingLanguageRules programmingLanguageRules, IMapper mapper)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
            _programmingLanguageRules = programmingLanguageRules;
            _mapper = mapper;
        }

        public async Task<ProgrammingLanguageGetByIdDto> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
        {
            ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

            _programmingLanguageRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

            ProgrammingLanguageGetByIdDto programmingLanguageGetByIdDto = _mapper.Map<ProgrammingLanguageGetByIdDto>(programmingLanguage);
            return programmingLanguageGetByIdDto;
        }
    }
}
