using System;
using System.Collections.Generic;

namespace Codenation.Challenge.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<Candidate> Candidates { get; set; }
    }
}