using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace kontent_sample_app_conference_net.Controllers
{
    public class SpeakersController : BaseController
    {
        public SpeakersController(IDeliveryClient deliveryClient, IConfiguration configuration) : base(deliveryClient, configuration)
        {

        }
        public async Task<ActionResult> Index(string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Speaker> response = await DeliveryClient.GetItemsAsync<Speaker>(
                new EqualsFilter("system.type", "speaker")
                );
            return base.GetResponse(response);   
        }

        public async Task<ActionResult> Detail(string id, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Speaker> response = await DeliveryClient.GetItemsAsync<Speaker>(
                new EqualsFilter("elements.speaker_id", id)
                );
            return base.GetResponse(response);
        }
    }
}