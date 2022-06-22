using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PassionProject_RecipeBookApp_AkshayaDupati.Models;

namespace PassionProject_RecipeBookApp_AkshayaDupati.Controllers
{
    public class RecipeIngredientsDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/RecipeIngredientsData/ListAllIngredients
        [HttpGet]
        public IEnumerable<RecipeIngredientDto> ListAllIngredients()
        {
            List<RecipeIngredient> RecipeIngredients = db.RecipeIngredients.ToList();
            List<RecipeIngredientDto> RecipeIngredientDtos = new List<RecipeIngredientDto>();

            RecipeIngredients.ForEach(a => RecipeIngredientDtos.Add(new RecipeIngredientDto()
            {
                RecipeIngredientID = a.RecipeIngredientID,
                RecipeName = a.Recipes.RecipeName,
                IngredientName = a.Ingredients.IngredientName,
                Quantity = a.Quantity,
                Unit = a.Unit
            }));
            return RecipeIngredientDtos;
        }
       

        // GET: api/RecipeIngredientsData/ListIngredientsForRecipes
        [HttpGet]
        [ResponseType(typeof (RecipeIngredientDto))]
        public IHttpActionResult ListIngredientsForRecipes(int id)
        {
            List<RecipeIngredient> RecipeIngredients = db.RecipeIngredients.Where(a => a.RecipeID == id).ToList();

            List<RecipeIngredientDto> RecipeIngredientDtos = new List<RecipeIngredientDto>();

            RecipeIngredients.ForEach(a => RecipeIngredientDtos.Add(new RecipeIngredientDto()
            {
                RecipeIngredientID = a.RecipeIngredientID,
                RecipeName = a.Recipes.RecipeName,
                IngredientName = a.Ingredients.IngredientName,
                Quantity = a.Quantity,
                Unit = a.Unit
            }));
            return Ok(RecipeIngredientDtos);
        }

        // GET: api/RecipeIngredientsData/ListRecipesForIngredients
        [HttpGet]
        [ResponseType(typeof(RecipeIngredientDto))]
        public IHttpActionResult ListRecipesForIngredients(int id)
        {
            //all animals that have keepers which match with our ID
            List<RecipeIngredient> RecipeIngredients = db.RecipeIngredients.Where(
               a => a.IngredientID == id).ToList();
            List<RecipeIngredientDto> RecipeIngredientDtos = new List<RecipeIngredientDto>();

            RecipeIngredients.ForEach(a => RecipeIngredientDtos.Add(new RecipeIngredientDto()
            {
                RecipeIngredientID = a.RecipeIngredientID,
                RecipeName = a.Recipes.RecipeName,
                IngredientName = a.Ingredients.IngredientName,
                Quantity = a.Quantity,
                Unit = a.Unit
            }));

            return Ok(RecipeIngredientDtos);
        }





        // GET: api/RecipeIngredientsData/FindIngredient/5
        [ResponseType(typeof(RecipeIngredient))]
        [HttpGet]
        public IHttpActionResult FindIngredient(int id)
        {
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Find(id);
            RecipeIngredientDto RecipeIngredientDto = new RecipeIngredientDto()
            {
                RecipeIngredientID = recipeIngredient.RecipeIngredientID,
                IngredientName = recipeIngredient.Ingredients.IngredientName,
                RecipeName = recipeIngredient.Recipes.RecipeName,
                Quantity = recipeIngredient.Quantity,
                Unit=recipeIngredient.Unit
            };
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            return Ok(RecipeIngredientDto);
        }

        // POST: api/RecipeIngredientsData/UpdateIngredient/5
        [ResponseType(typeof(void))]
        [HttpPost]
        public IHttpActionResult UpdateIngredient(int id, RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != recipeIngredient.RecipeIngredientID)
            {
                return BadRequest();
            }

            db.Entry(recipeIngredient).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecipeIngredientExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/RecipeIngredientsData/AddIngredient
        [ResponseType(typeof(RecipeIngredient))]
        [HttpPost]
        public IHttpActionResult AddIngredient(RecipeIngredient recipeIngredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RecipeIngredients.Add(recipeIngredient);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = recipeIngredient.RecipeIngredientID }, recipeIngredient);
        }

        // POST: api/RecipeIngredientsData/DeleteIngredient/{recipeid}/{ingredientid}
        [ResponseType(typeof(RecipeIngredient))]
        [HttpPost]
        public IHttpActionResult DeleteIngredientFromRecipe(int recipeid, int ingredientid)
        {
            RecipeIngredient recipeIngredient = db.RecipeIngredients.Where(a => a.RecipeID == recipeid && a.IngredientID == ingredientid).FirstOrDefault(); ;
            if (recipeIngredient == null)
            {
                return NotFound();
            }

            db.RecipeIngredients.Remove(recipeIngredient);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RecipeIngredientExists(int id)
        {
            return db.RecipeIngredients.Count(e => e.RecipeIngredientID == id) > 0;
        }
    }
}