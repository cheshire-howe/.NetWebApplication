using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Model.Interfaces;
using AutofacGenericRepositoryMvc.Repository.Interfaces;
using AutofacGenericRepositoryMvc.Service.Abstract;
using AutofacGenericRepositoryMvc.Service.DataTransferObjects;
using AutofacGenericRepositoryMvc.Service.Interfaces;

namespace AutofacGenericRepositoryMvc.Service.Concrete
{
    public class PersonService : EntityService<Person>, IPersonService
    {
        private IUnitOfWork _unitOfWork;
        private IPersonRepository _personRepository;
        private ILanguageRepository _languageRepository;

        public PersonService(IUnitOfWork unitOfWork, IPersonRepository personRepository, ILanguageRepository languageRepository)
            : base(unitOfWork, personRepository)
        {
            _unitOfWork = unitOfWork;
            _personRepository = personRepository;
            _languageRepository = languageRepository;
        }

        public Person GetById(long id)
        {
            return _personRepository.GetById(id);
        }

        public void CreatePersonFromDto(PersonDto personDto)
        {
            var languages = CreateListOfLanguagesFromString(personDto.Languages);

            var person = new Person
            {
                Name = personDto.Name,
                Phone = personDto.Phone,
                Address = personDto.Address,
                State = personDto.State,
                CountryId = personDto.CountryId,
                Languages = languages
            };

            Create(person);
        }

        public void UpdatePersonFromDto(PersonDto personDto)
        {
            var personToUpdate = _personRepository.GetById(personDto.Id);

            personToUpdate.Name = personDto.Name;
            personToUpdate.Phone = personDto.Phone;
            personToUpdate.Address = personDto.Address;
            personToUpdate.State = personDto.State;
            personToUpdate.CountryId = personDto.CountryId;

            if (personDto.Languages == "")
            {
                personToUpdate.Languages = new List<Language>();
                Update(personToUpdate);
                return;
            }

            var p = Regex.Replace(personDto.Languages, @"\s+", "");
            string[] updatedLanguages = p.Split(',');

            var personLanguages = new HashSet<int>(personToUpdate.Languages.Select(c => c.Id));

            var languagesInDb = _languageRepository.GetAll().ToList();

            foreach (var updatedLanguage in updatedLanguages)
            {
                var lang = languagesInDb.SingleOrDefault(l => l.Name == updatedLanguage) ?? null;
                if (lang == null)
                {
                    personToUpdate.Languages.Add(new Language()
                    {
                        Name = updatedLanguage
                    });
                }
            }

            foreach (var language in languagesInDb)
            {
                if (updatedLanguages.Contains(language.Name))
                {
                    if (!personLanguages.Contains(language.Id))
                    {
                        personToUpdate.Languages.Add(language);
                    }
                }
                else
                {
                    if (personLanguages.Contains(language.Id))
                    {
                        personToUpdate.Languages.Remove(language);
                    }
                }
            }

            Update(personToUpdate);
        }

        private List<Language> CreateListOfLanguagesFromString(string languageString)
        {
            var p = Regex.Replace(languageString, @"\s+", "");
            string[] s = p.Split(',');

            var languages = new List<Language>();
            foreach (string t in s)
            {
                Language l;
                var lang = _languageRepository.GetByName(t) ?? null;
                if (lang != null)
                {
                    l = lang;
                }
                else
                {
                    l = new Language()
                    {
                        Name = t
                    };
                }
                languages.Add(l);
            }

            return languages;
        }
    }
}
