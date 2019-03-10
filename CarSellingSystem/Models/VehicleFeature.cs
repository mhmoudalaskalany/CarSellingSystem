using System.ComponentModel.DataAnnotations.Schema;

namespace CarSellingSystem.Models
{
    [Table("VehicleFeatures")]
    public class VehicleFeature
    {
        public int VehicleId { get; set; }
        public int FeatureId { get; set; }
        public Feature Feature { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
