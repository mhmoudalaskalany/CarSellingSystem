using System.Collections;
using System.Collections.Generic;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Models;

namespace CarSellingSystem.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
            CreateMap<Feature, FeatureResource>();
        }
    }
}
