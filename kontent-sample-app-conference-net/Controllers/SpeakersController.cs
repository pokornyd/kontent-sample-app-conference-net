using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class SpeakersController : BaseController
    {
        public SpeakersController(IDeliveryClient deliveryClient): base(deliveryClient)
        {

        }
        public async Task<ActionResult> Index(string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Speaker> response = await DeliveryClient.GetItemsAsync<Speaker>(
                new EqualsFilter("system.type", "speaker")
                );
            //return base.GetResponse(response);   
            return View(response.Items);
        }

        public async Task<ActionResult> Detail(string id, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Speaker> response = await DeliveryClient.GetItemsAsync<Speaker>(
                new EqualsFilter("elements.speaker_id", id)
                );
            //return base.GetResponse(response);
            return View(response.Items[0]);
        }
    }
}