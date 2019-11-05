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

        protected IDeliveryClient DeliveryClient { get; }
    }
}