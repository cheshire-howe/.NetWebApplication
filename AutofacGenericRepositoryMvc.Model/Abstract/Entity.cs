using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Interfaces;

namespace AutofacGenericRepositoryMvc.Model.Abstract
{
    public abstract class BaseEntity
    {
    }

    public abstract class Entity<T> : BaseEntity, IEntity<T>, IObjectWithState
    {
        [Key]
        public virtual T Id { get; set; }

        [NotMapped]
        public virtual ObjectState ObjectState { get; set; }
    }
}
