using KenticoKontentModels;
using Kentico.Kontent.Delivery;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kontent_sample_app_conference_net.ViewComponents
{
    public class SpeakerAgendaItemViewComponent: ViewComponent
    {
        private IDeliveryClient _deliveryClient;

        public SpeakerAgendaItemViewComponent(IDeliveryClient deliveryClient)
        {
            _deliveryClient = deliveryClient;
        }
        public async Task<IViewComponentResult> InvokeAsync(string speakerCodename, string location)
        {
            DeliveryItemListingResponse<AgendaItem> response = await _deliveryClient. GetItemsAsync<AgendaItem>(
                new EqualsFilter("system.type", AgendaItem.Codename),
                new ContainsFilter("elements.speakers", speakerCodename),
                new ContainsFilter("elements.location", location.ToLower())
                );

            return View("SpeakerAgendaItem", response.Items);
        }
    }
}
