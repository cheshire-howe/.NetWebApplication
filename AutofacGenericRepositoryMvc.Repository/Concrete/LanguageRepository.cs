using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Repository.Abstract;
using AutofacGenericRepositoryMvc.Repository.Interfaces;

namespace AutofacGenericRepositoryMvc.Repository.Concrete
{
    public class LanguageRepository : GenericRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(DbContext context)
            : base(context)
        {
            
        }

        public Language GetById(int id)
        {
            return FindBy(x => x.Id == id).FirstOrDefault();
        }

        public Language GetByName(string name)
        {
            return FindBy(x => x.Name == name).FirstOrDefault();
        }
    }
}
