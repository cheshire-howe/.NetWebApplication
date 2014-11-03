using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutofacGenericRepositoryMvc.Model.Interfaces;

namespace AutofacGenericRepositoryMvc.Repository.Helpers
{
    public static class ContextHelpers
    {
        // Use only with short-lived contexts
        public static void ApplyStateChanges(this DbContext context)
        {
            foreach (var entry in context.ChangeTracker.Entries<IObjectWithState>())
            {
                IObjectWithState stateInfo = entry.Entity;
                entry.State = StateHelpers.ConvertState(stateInfo.ObjectState);
            }
        }
    }
}
