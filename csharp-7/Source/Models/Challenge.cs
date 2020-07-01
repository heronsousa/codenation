using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [MaxLength(100)]
        public string name { get; set; }
        [MaxLength(50)]
        public string slug { get; set; }
        public DateTime created_at { get; set; }
        public List<Submission> Submissions { get; set; }
        public List<Acceleration> Accelerations { get; set; }
    }
}