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
    public class AgendaController : BaseController
    {
        public  AgendaController(IDeliveryClient deliveryClient, IConfiguration configuration) : base(deliveryClient, configuration)
        {

        }

        public async Task<ActionResult> Index(string id, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<AgendaBlock> response = await DeliveryClient.GetItemsAsync<AgendaBlock>(
                new EqualsFilter("system.type", "agenda_block"),
                new ContainsFilter("elements.location", location.ToLower()),
                new DepthParameter(2)
                );

            return base.GetResponse(response);
        }

        public async Task<ActionResult> Detail(string urlSlug, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<AgendaItem> response = await DeliveryClient.GetItemsAsync<AgendaItem>(
                new EqualsFilter("system.type", "agenda_item"),
                new ContainsFilter("elements.location", location.ToLower()),
                new EqualsFilter("elements.url_slug", urlSlug),
                new DepthParameter(2)
                );

            return base.GetResponse(response);
        }
    }
}