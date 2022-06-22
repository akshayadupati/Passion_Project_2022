using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PassionProject_RecipeBookApp_AkshayaDupati.Models
{
    public class Recipe
    {

        [Key]
        public int RecipeID { get; set; }

        public string RecipeName { get; set;}

        public string RecipeDescription { get; set; }


    }
}