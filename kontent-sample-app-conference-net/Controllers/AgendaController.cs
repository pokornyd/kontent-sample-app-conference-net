using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class AgendaController : BaseController
    {
        public  AgendaController(IDeliveryClient deliveryClient) : base(deliveryClient)
        {

        }

        public async Task<ViewResult> Index(string id, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<AgendaBlock> response = await DeliveryClient.GetItemsAsync<AgendaBlock>(
                new EqualsFilter("system.type", "agenda_block"),
                new ContainsFilter("elements.location", location.ToLower()),
                new DepthParameter(2)
                );

            return View(response.Items[0]);
        }

        public async Task<ViewResult> Detail(string urlSlug, string location)
        {
            ViewBag.location = location;

            DeliveryItemListingResponse<AgendaItem> response = await DeliveryClient.GetItemsAsync<AgendaItem>(
                new EqualsFilter("system.type", "agenda_item"),
                new ContainsFilter("elements.location", location.ToLower()),
                new EqualsFilter("elements.url_slug", urlSlug),
                new DepthParameter(2)
                );

            return View(response.Items[0]);
        }
    }
}