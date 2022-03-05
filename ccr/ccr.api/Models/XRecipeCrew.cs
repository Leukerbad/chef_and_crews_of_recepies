using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class XRecipeCrew
    {
        public int IdRecipe { get; set; }
        public int IdCrew { get; set; }
        public string? StateOfRecipe { get; set; }

        public virtual Crew IdCrewNavigation { get; set; } = null!;
        public virtual Recipe IdRecipeNavigation { get; set; } = null!;
    }
}
