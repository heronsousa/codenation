using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Modelagem
{
    class Player
    {

        public long id { get; set; }
        public long teamId { get; set; }
        public string name { get; set; }
        public DateTime birthDate { get; set; }
        public int skillLevel { get; set; }
        public decimal salary { get; set; }

    }
}
