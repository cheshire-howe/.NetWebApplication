using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Service.DataTransferObjects;

namespace AutofacGenericRepositoryMvc.Service.Interfaces
{
    public interface IPersonService : IEntityService<Person>
    {
        Person GetById(long id);
        void CreatePersonFromDto(PersonDto personDto);
        void UpdatePersonFromDto(PersonDto personDto);
    }
}
