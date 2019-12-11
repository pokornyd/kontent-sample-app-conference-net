using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace kontent_sample_app_conference_net.Controllers
{
    public class HomeController : BaseController
    {

        public HomeController(IDeliveryClient deliveryClient) : base(deliveryClient)
        {

        }

        public async Task<ActionResult> Index(string location)
        {
            ViewBag.location = location;

            var response = await DeliveryClient.GetItemsAsync<Home>(
                new EqualsFilter("system.type", "home"),
                new ContainsFilter("elements.location", location.ToLower())
                );

            //return base.GetResponse(response);
            return View(response.Items[0]);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
