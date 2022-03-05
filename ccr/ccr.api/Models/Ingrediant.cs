using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class Ingrediant
    {
        public Ingrediant()
        {
            XRecipeIngrediants = new HashSet<XRecipeIngrediant>();
            IdChefs = new HashSet<Chef>();
        }

        public int IdIngrediant { get; set; }
        public string? NameIngrediant { get; set; }

        public virtual ICollection<XRecipeIngrediant> XRecipeIngrediants { get; set; }

        public virtual ICollection<Chef> IdChefs { get; set; }
    }
}
