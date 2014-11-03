using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Concrete;

namespace AutofacGenericRepositoryMvc.Repository.Interfaces
{
    public interface ICountryRepository : IGenericRepository<Country>
    {
        Country GetById(int id);
    }
}
