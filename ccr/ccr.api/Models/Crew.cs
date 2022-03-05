using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class Crew
    {
        public Crew()
        {
            XRecipeCrews = new HashSet<XRecipeCrew>();
            IdChefs = new HashSet<Chef>();
        }

        public int IdCrew { get; set; }
        public string? NameCrew { get; set; }

        public virtual ICollection<XRecipeCrew> XRecipeCrews { get; set; }

        public virtual ICollection<Chef> IdChefs { get; set; }
    }
}
