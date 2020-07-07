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
            var challenges = _context.Submissions
                .Where(s => s.UserId == userId)
                .Select(s => s.Challenge)
                .ToList();

            var accelerationService = new AccelerationService(_context);
            var acceleration = accelerationService.FindById(accelerationId);

            challenges.Add(acceleration.Challenge);

            return challenges;
        }

        public Models.Challenge Save(Models.Challenge challenge)
        {
            if (challenge.Id == 0)
                _context.Add(challenge);
            else
                _context.Update(challenge);
            _context.SaveChanges();

            return challenge;
        }
    }
}