using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PassionProject_RecipeBookApp_AkshayaDupati.Models
{
    public class Ingredient
    {

        [Key]

        public int IngredientID { get; set; }

        public string IngredientName { get; set; }
    }
}