using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace kontent_sample_app_conference_net.Controllers
{
    public class SponsorsController : BaseController
    {
        public SponsorsController(IDeliveryClient deliveryClient, IConfiguration configuration) : base(deliveryClient, configuration)
        {

        }

        public async Task<ActionResult> Index(string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<Sponsor> response = await DeliveryClient.GetItemsAsync<Sponsor>(
                new EqualsFilter("system.type", "sponsor")
                );
            return base.GetResponse(response);
        }
    }
}