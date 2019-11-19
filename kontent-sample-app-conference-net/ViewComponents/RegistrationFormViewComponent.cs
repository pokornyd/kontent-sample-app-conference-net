using Kentico.Kontent.Delivery;
using KenticoKontentModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kontent_sample_app_conference_net.ViewComponents
{
    public class RegistrationFormViewComponent: ViewComponent
    {
        private IDeliveryClient _deliveryClient;

        public RegistrationFormViewComponent(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }

        public async Task<IViewComponentResult> InvokeAsync(string speakerCodename, string location)
        {
            DeliveryItemListingResponse<HubspotForm> response = await _deliveryClient.GetItemsAsync<HubspotForm>(
                new EqualsFilter("system.type", HubspotForm.Codename)
                );

            return View("RegistrationForm", response.Items);
        }
    }
}
