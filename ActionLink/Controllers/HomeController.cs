using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Web.Mvc;
using ActionLink.Models;

namespace ActionLink.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListActionLink() {
            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            ViewBag.ListPost = JsonConvert.DeserializeObject<List<Post>>(response.Content);

            return View();
        }

        //[HttpGet]
        //public JsonResult ListPostGet(int id) {


        //    return Json();
        //}

        //[HttpGet]
        public ActionResult PartialTable(int id) {

            var client = new RestClient("https://jsonplaceholder.typicode.com/posts");
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            Console.WriteLine(response.Content);

            var PostList = JsonConvert.DeserializeObject<List<Post>>(response.Content);

            var getIdPost = PostList.Where(w => w.id == id).FirstOrDefault();
            return PartialView(getIdPost);
        }

    }
}