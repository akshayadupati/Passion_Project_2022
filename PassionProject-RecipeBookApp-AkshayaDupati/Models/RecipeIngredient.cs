using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PassionProject_RecipeBookApp_AkshayaDupati.Models
{
    public class RecipeIngredient
    {
        [Key]

        public int RecipeIngredientID { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        [ForeignKey("Recipes")]

        public int RecipeID { get; set; }

        public virtual Recipe Recipes { get; set; }

        [ForeignKey("Ingredients")]

        public int IngredientID { get; set; }

        public virtual Ingredient Ingredients { get; set; }
        
    }

    public class RecipeIngredientDto
    {
        public int RecipeIngredientID { get; set; }

        public int Quantity { get; set; }

        public string Unit { get; set; }

        public string IngredientName { get; set; }

        public string RecipeName { get; set; }
    }
}