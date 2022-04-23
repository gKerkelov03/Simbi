using AutoMapper;
using Simbi.Data.Models;
using Simbi.Services.Models;

namespace Simbi.Mappings;

public class EntitiesToServiceModelsProfile : Profile
{
    public EntitiesToServiceModelsProfile()
    {
        CreateMap<PurchaseEntity, PurchaseServiceModel>().ReverseMap();
        CreateMap<AdminRemarkEntity, AdminRemarkServiceModel>().ReverseMap();
        CreateMap<MaterialEntity, MaterialServiceModel>().ReverseMap();
        CreateMap<OrderEntity, OrderServiceModel>().ReverseMap();        
    }
}
