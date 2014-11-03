using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;

namespace AutofacGenericRepositoryMvc.Service.Interfaces
{
    public interface ILanguageService : IEntityService<Language>
    {
        Language GetById(int id);
        Language GetByName(string name);
    }
}
