using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class Chef
    {
        public Chef()
        {
            IdCrews = new HashSet<Crew>();
            IdIngrediants = new HashSet<Ingrediant>();
            IdRecipes = new HashSet<Recipe>();
        }

        public int IdChef { get; set; }
        public string? NameChef { get; set; }
        public string? EmailChef { get; set; }
        public string? PasswordChef { get; set; }

        public virtual ICollection<Crew> IdCrews { get; set; }
        public virtual ICollection<Ingrediant> IdIngrediants { get; set; }
        public virtual ICollection<Recipe> IdRecipes { get; set; }
    }
}
