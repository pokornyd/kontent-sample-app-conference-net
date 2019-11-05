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
            {typeof(HostedVideo), "hosted_video"},
            {typeof(Presentation), "presentation"},
            {typeof(PresentationMaterials), "presentation_materials"},
            {typeof(Room), "room"},
            {typeof(Speaker), "speaker"},
            {typeof(Sponsor), "sponsor"},
            {typeof(Tweet), "tweet"},
            {typeof(Venue), "venue"}
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