using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryBookLending.Models;
using Newtonsoft.Json;

namespace LibraryBookLending.Controllers
{
    public class LibrariesController : Controller
    {
        // GET: Libraries
        [HttpGet]
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {               
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = "https://aka-library-api.azurewebsites.net/api/libraries";

                using (var response = await client.GetAsync(url))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var libraryList = JsonConvert.DeserializeObject<List<Library>>(resp);
                        return View(libraryList);
                    }
                    else
                    {
                        //TODO: display a freindly error in the event of failure.
                        throw new Exception(
                            string.Format("{0}-{1}",
                                (int)response.StatusCode, response.StatusCode));
                    }
                }
            }
                
        }
    }
}