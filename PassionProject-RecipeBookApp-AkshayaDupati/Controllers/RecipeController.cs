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
    public class RecipeController : Controller
    {

        private static readonly HttpClient client;
        private JavaScriptSerializer jss = new JavaScriptSerializer();

        public object ViewModel { get; private set; }

        static RecipeController()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:44371/api/recipedata/");
        }
        // GET: Recipe/List
        public ActionResult List()
        {
            string url = "listrecipes";
            HttpResponseMessage response = client.GetAsync(url).Result;

            /* Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode); */

            IEnumerable<Recipe> recipes = response.Content.ReadAsAsync<IEnumerable<Recipe>>().Result;

            /* Debug.WriteLine("Number of recipes");
            Debug.WriteLine(recipes.Count()); */

            return View(recipes);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int id)
        {
            string url = "findrecipe/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;

            /* Debug.WriteLine("The response code is ");
            Debug.WriteLine(response.StatusCode); */

            Recipe selectedRecipe = response.Content.ReadAsAsync<Recipe>().Result;

            /* Debug.WriteLine("Number of recipes");
            Debug.WriteLine(selectedRecipe.RecipeName); */

            return View(selectedRecipe);
        }

        public ActionResult Error()
        {
            return View();
        }

        // GET: Recipe/Create
        public ActionResult New()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            Debug.WriteLine("Inputted recipe is");
            Debug.WriteLine(recipe.RecipeName);

            string url = "addrecipe";

            string jsonpayload = jss.Serialize(recipe);

            Debug.WriteLine(jsonpayload);

            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";

            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
            
           
        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int id)
        {
            Debug.WriteLine("id here" + id);
            string url = "findrecipe/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Debug.WriteLine("response" + response);
            Recipe SelectedRecipe = response.Content.ReadAsAsync<Recipe>().Result;

            return View(SelectedRecipe);

        }

        // POST: Recipe/Edit/5
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

        // GET: Recipe/DeleteConfirm/5
        public ActionResult DeleteConfirm(int id)
        {

            string url = "findrecipe/" + id;
            HttpResponseMessage response = client.GetAsync(url).Result;
            Recipe selectedrecipe = response.Content.ReadAsAsync<Recipe>().Result;
            return View(selectedrecipe);
        }

        // POST: Recipe/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string url = "deleterecipe/" + id;
            HttpContent content = new StringContent("");
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }



        // POST: Recipe/Update/5
        [HttpPost]
        public ActionResult Update(int id, Recipe recipe)
        {
            string url = "updaterecipe/" + id;
            string jsonpayload = jss.Serialize(recipe);
            HttpContent content = new StringContent(jsonpayload);
            content.Headers.ContentType.MediaType = "application/json";
            HttpResponseMessage response = client.PostAsync(url, content).Result;

            //update request is successful, and we have image data
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Error");
            }
        }
    }
}
