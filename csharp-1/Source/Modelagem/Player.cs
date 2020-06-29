using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Modelagem
{
    class Player
    {

        public Player(long id, long teamId, string name, DateTime birthDate, int skillLevel, decimal salary)
        {
            this.id = id;
            this.teamId = teamId;
            this.name = name;
            this.birthDate = birthDate;
            this.skillLevel = skillLevel;
            this.salary = salary;
        }

        public long id { get; set; }
        public long teamId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public int skillLevel { get; set; }
        public decimal salary { get; set; }
        public bool isCaptain { get; set; } = false;

    }
}
