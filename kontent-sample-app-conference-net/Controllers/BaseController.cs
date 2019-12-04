using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kentico.Kontent.Delivery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace kontent_sample_app_conference_net.Controllers
{
    public class BaseController : Controller
    {
        public BaseController(IDeliveryClient deliveryClient, IConfiguration configuration)
        {
            DeliveryClient = deliveryClient;
            Configuration = configuration;
        }

        protected IDeliveryClient DeliveryClient { get; }
        protected IConfiguration Configuration { get; }

        public ActionResult GetResponse<T>(DeliveryItemListingResponse<T> response)
        {
            if (response.Items.Count == 0)
            {
                return StatusCode(404, "The page you're looking for doesn't exists.");
            }
            else
            {
                return View(response.Items[0]);
            }
        }

        protected String GetEditURL(String variantCodeName, String itemId)
        {
            String urlTemplate = "https://app.kenticocloud.com/goto/edit-item/project/{0}/variant-codename/{1}/item/{2}";

            return String.Format(urlTemplate, GetProjectId(), variantCodeName, itemId);
        }

        private String GetProjectId()
        {
            string result = Configuration.GetSection("DeliveryOptions").GetValue<string>("ProjectId");

            return result;
        }
    }
}