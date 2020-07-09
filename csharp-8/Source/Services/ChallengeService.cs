using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class ChallengeService : IChallengeService
    {
        private CodenationContext _context;

        public ChallengeService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Models.Challenge> FindByAccelerationIdAndUserId(int accelerationId, int userId)
        {
            return _context.Candidates
                .Where(s => s.UserId == userId && s.AccelerationId == accelerationId)
                .Select(s => s.Acceleration.Challenge)
                .Distinct()
                .ToList();
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Challenges.Add(challenge);
            else
                _context.Challenges.Update(challenge);

            _context.SaveChanges();

            return challenge;
        }
    }
}