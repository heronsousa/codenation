using System;
using System.Collections.Generic;
using System.Text;

namespace Source.Modelagem
{
    class Team
    {

        public Team(long id, string name, DateTime createDate, string mainShirtColor, string secondaryShirtColor)
        {
            this.id = id;
            this.name = name;
            this.createDate = createDate;
            this.mainShirtColor = mainShirtColor;
            this.secondaryShirtColor = secondaryShirtColor;
        }

        public long id { get; set; }
        public string name { get; set; }
        public DateTime createDate { get; set; }
        public string mainShirtColor { get; set; }
        public string secondaryShirtColor { get; set; }
        public long captainId { get; set; } = -1;
    }
}
