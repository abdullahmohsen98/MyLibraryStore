using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyLibraryStore.Data;
using MyLibraryStore.Models;

namespace MyLibraryStore.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly MyLibraryStoreContext _context = null;

        public LanguageRepository(MyLibraryStoreContext context)
        {
            _context = context;
        }

        public async Task<List<LanguageModel>> GetLanguages()
        {
            return await _context.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name
            }).ToListAsync();
        }

    }
}
