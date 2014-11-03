using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Repository.Interfaces;
using AutofacGenericRepositoryMvc.Service.Abstract;
using AutofacGenericRepositoryMvc.Service.Interfaces;

namespace AutofacGenericRepositoryMvc.Service.Concrete
{
    public class LanguageService : EntityService<Language>, ILanguageService
    {
        private IUnitOfWork _unitOfWork;
        private ILanguageRepository _languageRepository;

        public LanguageService(IUnitOfWork unitOfWork, ILanguageRepository languageRepository)
            : base(unitOfWork, languageRepository)
        {
            _unitOfWork = unitOfWork;
            _languageRepository = languageRepository;
        }

        public Language GetById(int id)
        {
            return _languageRepository.GetById(id);
        }

        public Language GetByName(string name)
        {
            return _languageRepository.GetByName(name);
        }
    }
}
