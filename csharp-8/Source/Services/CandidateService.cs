 using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;
using Microsoft.EntityFrameworkCore;

namespace Codenation.Challenge.Services
{
    public class CandidateService : ICandidateService
    {
        private CodenationContext _context;

        public CandidateService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Candidate> FindByAccelerationId(int accelerationId)
        {
            return _context.Candidates
                .Where(c => c.AccelerationId == accelerationId)
                .ToList();
        }

        public IList<Candidate> FindByCompanyId(int companyId)
        {
            return _context.Candidates
                .Where(c => c.CompanyId == companyId)
                .ToList();
        }

        public Candidate FindById(int userId, int accelerationId, int companyId)
        {
            return _context.Candidates
                .Where(c => c.UserId == userId && c.AccelerationId == accelerationId && c.CompanyId == companyId)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public Candidate Save(Candidate candidate)
        {
            var checkCandidate = FindById(candidate.UserId, candidate.AccelerationId, candidate.CompanyId);

            if (checkCandidate == null)
                _context.Candidates.Add(candidate);
            else
                _context.Candidates.Update(candidate);
                
            _context.SaveChanges();

            return candidate;
        }
    }
}
