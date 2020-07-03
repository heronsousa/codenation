using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id"), Required]
        public int Id { get; set; }

        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }

        [Column("name"), MaxLength(100), Required]
        public string Name { get; set; }

        [Column("slug"), MaxLength(50), Required]
        public string Slug { get; set; }

        [Column("created_at"), Required]
        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
    }
}