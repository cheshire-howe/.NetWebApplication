using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Abstract;

namespace AutofacGenericRepositoryMvc.Service.Interfaces
{
    public interface IEntityService<T> : IService
        where T : BaseEntity
    {
        void Create(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(T entity);
    }
}
