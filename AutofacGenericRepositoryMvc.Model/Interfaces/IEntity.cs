using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutofacGenericRepositoryMvc.Model.Interfaces
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }
}
