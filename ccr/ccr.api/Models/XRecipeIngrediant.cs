using System;
using System.Collections.Generic;

namespace ccr.api.Models
{
    public partial class XRecipeIngrediant
    {
        public int IdRecipe { get; set; }
        public int IdIngrediant { get; set; }
        public int? Quantity { get; set; }

        public virtual Ingrediant IdIngrediantNavigation { get; set; } = null!;
        public virtual Recipe IdRecipeNavigation { get; set; } = null!;
    }
}
