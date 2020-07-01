using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [MaxLength(100)]
        public string full_name { get; set; }
        [MaxLength(100)]
        public string email { get; set; }
        [MaxLength(50)]
        public string nickname { get; set; }
        [MaxLength(255)]
        public string password { get; set; }
        public DateTime created_at { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}