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
    public class ManageBookController : Controller
    {
        // POST: ManageBook

        [Route("Libraries/{libraryId}/books/{bookId}/signout/{memberId}")]
        public async Task<ActionResult> SignoutBook(int libraryId = 1,int bookId = 1,int memberId = 1)
        {
            using(HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = string.Format("https://aka-library-api.azurewebsites.net/api/libraries/{0}/books/{1}/signout/{2}", libraryId, bookId, memberId);

                using (var response = await client.PostAsync(url,null))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var bookscheckedout = JsonConvert.DeserializeObject<BookSignout>(resp);
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