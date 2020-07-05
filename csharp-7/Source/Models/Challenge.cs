using System;
using System.Collections.Generic;

namespace Codenation.Challenge.Models
{
    public class Challenge
    {
        public int ChallengeId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Submission> Submissions { get; set; }
        public List<Acceleration> Accelerations { get; set; }
    }
}