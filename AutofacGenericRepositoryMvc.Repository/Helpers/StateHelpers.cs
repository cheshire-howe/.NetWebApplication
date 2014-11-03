using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Interfaces;

namespace AutofacGenericRepositoryMvc.Repository.Helpers
{
    public class StateHelpers
    {
        public static EntityState ConvertState(ObjectState objectState)
        {
            switch (objectState)
            {
                case ObjectState.Added:
                    return EntityState.Added;
                case ObjectState.Modified:
                    return EntityState.Modified;
                case ObjectState.Deleted:
                    return EntityState.Deleted;
                default:
                    return EntityState.Unchanged;
            }
        }

        public static ObjectState ConvertState(EntityState entityState)
        {
            switch (entityState)
            {
                case EntityState.Added:
                    return ObjectState.Added;
                case EntityState.Modified:
                    return ObjectState.Modified;
                case EntityState.Deleted:
                    return ObjectState.Deleted;
                default:
                    return ObjectState.Unchanged;
            }
        }
    }
}
