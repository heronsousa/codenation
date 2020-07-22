using System;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class QuoteService : IQuoteService
    {
        private ScriptsContext _context;
        private IRandomService _randomService;

        public QuoteService(ScriptsContext context, IRandomService randomService)
        {
            this._context = context;
            this._randomService = randomService;
        }

        public Quote GetAnyQuote()
        {
            return _context.Quotes
                .ElementAt(_randomService.RandomInteger(_context.Quotes.Count()));
        }

        public Quote GetAnyQuote(string actor)
        {
            return _context.Quotes
                .Where(q => q.Actor == actor)
                .FirstOrDefault();
        }
    }
}