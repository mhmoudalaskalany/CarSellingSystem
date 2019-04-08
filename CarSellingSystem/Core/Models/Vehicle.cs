using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using CarSellingSystem.Core.Models.OwnedTypes;

namespace CarSellingSystem.Core.Models
{
    [Table("Vehicles")]
    public class Vehicle
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public bool IsRegistered { get; set; }
        public Contact Contact { get; set; }
        public DateTime LastUpdate { get; set; }
        public Collection<VehicleFeature> Features { get; set; }

        public Vehicle()
        {
            Features = new Collection<VehicleFeature>();
        }
    }
}
