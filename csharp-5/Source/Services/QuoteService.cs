using System;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.AspNetCore.Mvc;

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
            int value = _randomService.RandomInteger(_context.Quotes.Count());
            
            return _context.Quotes
                .Skip(value)
                .First();
        }

        public Quote GetAnyQuote(string actor)
        {
            var result = _context.Quotes
                .Where(q => q.Actor == actor);

            int count = result.Count();

            if (count == 0)
                return null;

            int value = _randomService.RandomInteger(count);
            return result
                .Skip(value)
                .First();
        }
    }
}