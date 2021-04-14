using System.Collections.Generic;
using System.Threading.Tasks;
using MyLibraryStore.Models;

namespace MyLibraryStore.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetLanguages();
    }
}