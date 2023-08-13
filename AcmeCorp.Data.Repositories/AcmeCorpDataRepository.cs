using Microsoft.EntityFrameworkCore;
using AcmeCorp.Data.Context;

namespace AcmeCorp.Data.Repositories
{
    /// <summary>
    /// Abstract repository to provide the DbContact to all other data repo's
    /// </summary>
    public abstract class AcmeCorpDataRepository
    {
        private readonly AcmeCorpDataContext _context;

        protected AcmeCorpDataRepository(AcmeCorpDataContext context) { 
            _context = context;
        }

        protected AcmeCorpDataContext Context { get { return _context; } }

    }
}