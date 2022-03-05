using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class Recipe
    {
        public Recipe()
        {
            XRecipeCrews = new HashSet<XRecipeCrew>();
            XRecipeIngrediants = new HashSet<XRecipeIngrediant>();
            IdChefs = new HashSet<Chef>();
        }

        public int IdRecipe { get; set; }
        public string? NameRecipe { get; set; }
        public byte[]? ImageRecipe { get; set; }

        public virtual ICollection<XRecipeCrew> XRecipeCrews { get; set; }
        public virtual ICollection<XRecipeIngrediant> XRecipeIngrediants { get; set; }

        public virtual ICollection<Chef> IdChefs { get; set; }
    }
}
