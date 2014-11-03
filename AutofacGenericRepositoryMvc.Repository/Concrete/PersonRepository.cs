using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;
using AutofacGenericRepositoryMvc.Repository.Abstract;
using AutofacGenericRepositoryMvc.Repository.Helpers;
using AutofacGenericRepositoryMvc.Repository.Interfaces;

namespace AutofacGenericRepositoryMvc.Repository.Concrete
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext context)
            : base(context)
        {
            
        }

        public override IEnumerable<Person> GetAll()
        {
            return _entities.Set<Person>().Include(x => x.Country).Include(x => x.Languages).AsEnumerable();
        }

        public Person GetById(long id)
        {
            return _dbset.Include(x => x.Country).Include(x => x.Languages).FirstOrDefault(x => x.Id == id);
        }
    }
}
