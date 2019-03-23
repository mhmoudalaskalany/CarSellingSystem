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
            CreateMap<Vehicle, VehicleResource>()
                .ForPath(vr => vr.Contact , opt => opt.MapFrom(v => new ContactResource{Name = v.Contact.ContactName , Email = v.Contact.ContactEmail , Phone = v.Contact.ContactPhone}))
                .ForMember(vr => vr.Features , opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            //mapping from api resources to domain models
            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForPath(v => v.Contact.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForPath(v => v.Contact.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForPath(v => v.Contact.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    //user to list method to avoid exception (Collection was Modified During Iteration)
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                    foreach (var f in removedFeatures)
                        v.Features.Remove(f);

                    var addedFeatures = vr.Features.Where(id => v.Features.All(f => f.FeatureId != id))
                        .Select(id => new VehicleFeature {FeatureId = id});
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);
                });

        }
    }
}
