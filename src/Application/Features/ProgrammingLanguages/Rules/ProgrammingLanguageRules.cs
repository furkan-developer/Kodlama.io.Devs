using Application.Features.ProgrammingLanguages.Constants;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(predicate: p => p.Name == name, enableTracking: false);
            if (result.Items.Any()) throw new BusinessException(ProgrammingLanguageMessages.ProgrammingLanguageNameIsAlreadyExist);
        }

        public void ProgrammingLanguageShouldExistWhenRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested brand does not exist");
        }

        public void ProgrammingLanguageShouldExistWhenDeleteRequested(ProgrammingLanguage? programmingLanguage)
        {       
            if (programmingLanguage == null) throw new BusinessException("The programming language to be deleted does not exist"); 
        }

        public void ProgrammingLanguageShouldExistWhenUpdateRequested(ProgrammingLanguage? programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("The programming language to be updated  does not exist");
        }
    }
}
