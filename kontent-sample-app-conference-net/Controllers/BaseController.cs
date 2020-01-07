using System;
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

        protected String GetEditURL(String variantCodeName, String itemId)
        {
            String urlTemplate = "https://app.kenticocloud.com/goto/edit-item/project/{0}/variant-codename/{1}/item/{2}";

            return String.Format(urlTemplate, GetProjectId(), variantCodeName, itemId);
        }

        private String GetProjectId()
        {
            string result;

            if (HttpContext.Request.Host.ToString() == "konnections.herokuapp.com")
            {
                result = "db96e910-edf8-0094-b795-f3ce073c7ae0";//Configuration.GetSection("DeliveryOptions").GetValue<string>("ProjectId");
            }

            else
            {
                result = "db96e910-edf8-0094-b795-f3ce073c7ae0";
            }

            return result;
        }

    }
}
