using System.Collections.Generic;
using System.Linq;
using Codenation.Challenge.Models;

namespace Codenation.Challenge.Services
{
    public class SubmissionService : ISubmissionService
    {
        private CodenationContext _context;

        public SubmissionService(CodenationContext context)
        {
            _context = context;
        }

        public IList<Submission> FindByChallengeIdAndAccelerationId(int challengeId, int accelerationId)
        {
            var accelerationService = new AccelerationService(_context);
            var acceleration = accelerationService.FindById(accelerationId);

            var challenge = acceleration.Challenge;

            return _context.Submissions
                .Where(s => s.ChallengeId == challengeId && s.ChallengeId == challenge.Id)
                .ToList();
        }

        public decimal FindHigherScoreByChallengeId(int challengeId)
        {
            return _context.Submissions
                .Where(s => s.Challenge.Id == challengeId)
                .Max(s => s.Score);
        }

        public Submission Save(Submission submission)
        {
            if (submission.UserId == 0 && submission.ChallengeId == 0)
                _context.Add(submission);
            else
                _context.Update(submission);
            _context.SaveChanges();

            return submission;
        }
    }
}
