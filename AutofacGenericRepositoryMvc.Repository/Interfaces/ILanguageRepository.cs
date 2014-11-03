using AutofacGenericRepositoryMvc.Model.Concrete;

namespace AutofacGenericRepositoryMvc.Repository.Interfaces
{
    public interface ILanguageRepository : IGenericRepository<Language>
    {
        Language GetById(int id);
        Language GetByName(string name);
    }
}