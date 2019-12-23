using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class VenueController : BaseController
    {
        public VenueController(IDeliveryClient deliveryClient) : base(deliveryClient)
        {

        }
        public async Task<ActionResult> Index(string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Venue> response = await DeliveryClient.GetItemsAsync<Venue>(
                new EqualsFilter("system.type", "venue"),
                new ContainsFilter("elements.location", location.ToLower())
                );

            return View(response.Items);
        }
    }
}