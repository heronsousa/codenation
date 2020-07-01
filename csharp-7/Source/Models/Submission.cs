using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        public int user_id { get; set; }
        public int challenge_id { get; set; }
        [Column(TypeName = "decimal(9, 2)")]
        public decimal score { get; set; }
        public DateTime created_at { get; set; }
    }
}