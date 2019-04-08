using System;
using System.Collections.ObjectModel;
using CarSellingSystem.Core.Models;

namespace CarSellingSystem.ApiResources
{
    public class VehicleResource
    {
        public int Id { get; set; }
        public KeyValuePairResource Model { get; set; }
        public KeyValuePairResource Make { get; set; }
        public bool IsRegistered { get; set; }
        public ContactResource Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public Collection<Feature> Features { get; set; }

        public VehicleResource()
        {
            Features = new Collection<Feature>();
        }
    }
}
