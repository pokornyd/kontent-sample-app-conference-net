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
                new DepthParameter(4)
                );

            var item = response.Items[0];

            item.EditURL = base.GetEditURL(item.System.Language, item.System.Id);

            return View(item);
        }
    }
}