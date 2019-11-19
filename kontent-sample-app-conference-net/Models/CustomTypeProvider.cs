using System;
using System.Collections.Generic;
using System.Linq;
using Kentico.Kontent.Delivery;

namespace KenticoKontentModels
{
    public class CustomTypeProvider : ITypeProvider
    {
        private static readonly Dictionary<Type, string> _codenames = new Dictionary<Type, string>
        {
            {typeof(Agenda), "agenda"},
            {typeof(AgendaBlock), "agenda_block"},
            {typeof(AgendaItem), "agenda_item"},
            {typeof(ContactInformation), "contact_information"},
            {typeof(Home), "home"},
            {typeof(HubspotForm), "hubspot_form"},
            {typeof(Presentation), "presentation"},
            {typeof(Registration), "registration"},
            {typeof(Room), "room"},
            {typeof(Speaker), "speaker"},
            {typeof(Sponsor), "sponsor"},
            {typeof(Ticket), "ticket"},
            {typeof(Tweet), "tweet"},
            {typeof(Venue), "venue"},
            {typeof(YoutubeVideo), "youtube_video"}
        };

        public Type GetType(string contentType)
        {
            return _codenames.Keys.FirstOrDefault(type => GetCodename(type).Equals(contentType));
        }

        public string GetCodename(Type contentType)
        {
            return _codenames.TryGetValue(contentType, out var codename) ? codename : null;
        }
    }
}