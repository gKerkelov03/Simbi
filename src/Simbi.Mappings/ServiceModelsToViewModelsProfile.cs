using AutoMapper;
using Simbi.Services.Models;
using Simbi.WindowsForms.Models;

namespace Simbi.Mappings;

public class ServiceModelsToViewModelsProfile : Profile
{
    public ServiceModelsToViewModelsProfile()
    {
        CreateMap<PurchaseServiceModel, PurchaseViewModel>().ReverseMap();
        CreateMap<AdminRemarkServiceModel, AdminRemarkViewModel>().ReverseMap();
        CreateMap<MaterialServiceModel, MaterialViewModel>().ReverseMap();
        CreateMap<OrderServiceModel, OrderViewModel>().ReverseMap();
        CreateMap<OrderServiceModel, OrderWithoutPurchasesViewModel>().ReverseMap();
    }
}
