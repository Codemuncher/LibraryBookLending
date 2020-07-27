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
    public class MembersBooksController : Controller
    {
        // GET: MembersBooks
        [Route("Members/{memberId}/books/signedout/")]
        public async Task<ActionResult> MemberBooks(int memberId = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = string.Format("https://aka-library-api.azurewebsites.net/api/members/{0}/books/signedout", memberId);

                using (var response = await client.GetAsync(url))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var memberBooks = JsonConvert.DeserializeObject<List<MemberBook>>(resp);
                        return View(memberBooks);
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

        // GET: MembersBooks
        [Route("Members/{memberId}/books/history/")]
        public async Task<ActionResult> MemberBooksHistory(int memberId = 1)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(
                        new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                //make a call to api/libararies and return a list of libraries
                var url = string.Format("https://aka-library-api.azurewebsites.net/api/members/{0}/books/history", memberId);

                using (var response = await client.GetAsync(url))
                {
                    //Ensure call is successful or display an error.
                    if (response.IsSuccessStatusCode)
                    {
                        var resp = await response.Content.ReadAsStringAsync();
                        var memberBooks = JsonConvert.DeserializeObject<List<MemberBook>>(resp);
                        return View(memberBooks);
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