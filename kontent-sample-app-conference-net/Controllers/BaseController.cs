using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using Microsoft.AspNetCore.Mvc;

namespace kontent_sample_app_conference_net.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IDeliveryClient deliveryClient)
        {
            DeliveryClient = deliveryClient;
        }

        //public ActionResult GetResponse<T>(DeliveryItemListingResponse<T> response)
        //{
        //    if (response.Items.Count == 0)
        //    {
        //        return StatusCode(404, "The page you're looking for doesn't exists.");
        //    }
        //    else
        //    {
        //        return View(response.Items);
        //    }
        //}

        protected IDeliveryClient DeliveryClient { get; }
    }
}