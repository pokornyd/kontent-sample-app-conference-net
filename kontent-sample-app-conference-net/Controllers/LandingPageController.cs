using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class LandingPageController : BaseController
    {

        public LandingPageController(IDeliveryClient deliveryClient) : base(deliveryClient)
        {

        }

        public async Task<ActionResult> Index()
        {

            DeliveryItemListingResponse<Home> response = await DeliveryClient.GetItemsAsync<Home>(
                new EqualsFilter("system.type", "home")
                );

            if (response.Items.Count == 0)
            {
                return base.GetResponse(response);
            }
            else
            {
                if (response.Items.Count > 1)
                {
                    return View(response.Items);
                }
                else
                {
                    var loc = response.Items.First().Location.First().Name;
                    return RedirectToAction("Index", "Home", new { location = loc });
                }
            }
            
        }
    }
}