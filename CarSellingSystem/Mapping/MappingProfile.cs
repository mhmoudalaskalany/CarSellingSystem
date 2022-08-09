using System.Linq;
using AutoMapper;
using CarSellingSystem.ApiResources;
using CarSellingSystem.Core.Models;
namespace CarSellingSystem.Mapping
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //mapping from doamin models to api resources
            CreateMap<Make, MakeResource>();
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Feature, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForPath(vr => vr.Contact , opt => opt.MapFrom(v => new ContactResource{Name = v.Contact.ContactName , Email = v.Contact.ContactEmail , Phone = v.Contact.ContactPhone}))
                .ForMember(vr => vr.Features , opt => opt.MapFrom(v => v.Features.Select(vf => vf.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForPath(vr => vr.Contact, opt => opt.MapFrom(v => new ContactResource { Name = v.Contact.ContactName, Email = v.Contact.ContactEmail, Phone = v.Contact.ContactPhone }))
                .ForMember(vr => vr.Features,
                    opt => opt.MapFrom(v =>
                        v.Features.Select(vr => new KeyValuePairResource { Id = vr.Feature.Id, Name = vr.Feature.Name})))
                .ForPath(vr => vr.Make , opt => opt.MapFrom(v => v.Model.Make));
            //mapping from api resources to domain models
            CreateMap<FilterResource, FilterResource>();
            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id, opt => opt.Ignore())
                .ForPath(v => v.Contact.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForPath(v => v.Contact.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForPath(v => v.Contact.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) =>
                {
                    //use to list method to avoid exception (Collection was Modified During Iteration)
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
