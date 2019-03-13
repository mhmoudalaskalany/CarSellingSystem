using System.Linq;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Models;

namespace CarSellingSystem.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //mapping from doamin models to api resources
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();

        }
    }
}
