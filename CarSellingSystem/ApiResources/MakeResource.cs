
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace CarSellingSystem.ApiResources
{
    public class MakeResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ModelResource> ModelResources { get; set; }

        public MakeResource()
        {
            ModelResources = new Collection<ModelResource>();
        }
    }
}
