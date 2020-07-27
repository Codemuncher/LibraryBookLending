using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using LibraryBookLending.Models;
using Newtonsoft.Json;

namespace LibraryBookLending.Controllers
{
    public class LibraryBooksController : Controller
    {
        // GET: LibraryBooks availble at a specific library
        [Route("Libraries/{libraryId}/books/available")]
        [HttpGet]
       
        public async Task<ActionResult> AvailableBooks(int libraryId = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = string.Format("https://aka-library-api.azurewebsites.net/api/libraries/{0}/books/available",libraryId);

                using (var response = await client.GetAsync(url))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var booksavailable = JsonConvert.DeserializeObject<List<Book>>(resp);
                        return View(booksavailable);
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

        // GET: LibraryBooks availble at a specific library
        [Route("Libraries/{libraryId}/books/checkedout")]
        [HttpGet]

        public async Task<ActionResult> CheckedOutBooks(int libraryId = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = string.Format("https://aka-library-api.azurewebsites.net/api/libraries/{0}/books/checkedout", libraryId);

                using (var response = await client.GetAsync(url))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var bookscheckedout = JsonConvert.DeserializeObject<List<Book>>(resp);
                        return View(bookscheckedout);
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