using System;

namespace Codenation.Challenge.Models
{
    public class Candidate
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int AccelerationId { get; set; }
        public Acceleration Acceleration { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public int Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}