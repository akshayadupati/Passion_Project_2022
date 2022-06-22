using PassionProject_RecipeBookApp_AkshayaDupati.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace PassionProject_RecipeBookApp_AkshayaDupati.Controllers
{
    public class IngredientsController : Controller
    {

        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();
        static IngredientsController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/api/IngredientsData/");
        }

        // GET: Ingredients/List
        public ActionResult List()
        {
            string url = "ListIngredients";
            HttpResponseMessage response = client.GetAsync(url).Result;

            IEnumerable<Ingredient> ingredients = response.Content.ReadAsAsync<IEnumerable<Ingredient>>().Result;

            return View(ingredients);
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int id)
        {

            string url = "FindIngredient/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;


            Ingredient selectedIngredient = response.Content.ReadAsAsync<Ingredient>().Result;

            return View(selectedIngredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create(Ingredient ingredient)
        {
            string url = "AddIngredient";
            string jsonpayload = jss.Serialize(ingredient);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List", "Recipe");
            }
            else
            {
                return RedirectToAction("Error");
            }

            //return View();
        }

        // POST: Ingredients/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ingredients/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult New()
        {
            return View("New");
        }


        // POST: Ingredients/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
