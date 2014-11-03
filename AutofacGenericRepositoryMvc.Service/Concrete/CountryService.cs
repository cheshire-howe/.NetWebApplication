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
    public class CountryService : EntityService<Country>, ICountryService
    {
        private IUnitOfWork _unitOfWork;
        private ICountryRepository _countryRepository;

        public CountryService(IUnitOfWork unitOfWork, ICountryRepository countryRepository)
            : base(unitOfWork, countryRepository)
        {
            _unitOfWork = unitOfWork;
            _countryRepository = countryRepository;
        }

        public Country GetById(int id)
        {
            return _countryRepository.GetById(id);
        }
    }
}
