using AutoMapper;
using Company.Delivery.Core;
using Company.Delivery.Domain.Dto;

namespace Company.Delivery.Infrastructure.Mapping;

public class DefaultMapper : Profile
{
    public DefaultMapper()
    {
        CreateMap<Waybill, WaybillDto>();
        CreateMap<WaybillCreateDto, Waybill>();
        CreateMap<WaybillUpdateDto, Waybill>();
    }
}