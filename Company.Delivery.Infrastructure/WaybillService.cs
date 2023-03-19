using AutoMapper;
using Company.Delivery.Core;
using Company.Delivery.Database;
using Company.Delivery.Domain;
using Company.Delivery.Domain.Dto;
using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Infrastructure;

public class WaybillService : IWaybillService
{
    private readonly DeliveryDbContext _context;
    private readonly IMapper _mapper;
    public WaybillService(DeliveryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<WaybillDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills.AsNoTracking().FirstOrDefaultAsync(s=>s.Id == id, cancellationToken);
        if (waybill is null)
            throw new EntityNotFoundException();

        return _mapper.Map<WaybillDto>(waybill);
    }

    public async Task<WaybillDto> CreateAsync(WaybillCreateDto data, CancellationToken cancellationToken)
    {
        var toCreate = _mapper.Map<Waybill>(data);
        var waybill = await _context.Waybills.AddAsync(toCreate, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<WaybillDto>(waybill);
    }

    public async Task<WaybillDto> UpdateByIdAsync(Guid id, WaybillUpdateDto data, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (waybill is null)
            throw new EntityNotFoundException();

        _mapper.Map(data, waybill);
        var updatedWaybill = _context.Waybills.Update(waybill);
        await _context.SaveChangesAsync(cancellationToken);

        return _mapper.Map<WaybillDto>(updatedWaybill);
    }

    public async Task DeleteByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var waybill = await _context.Waybills.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
        if (waybill is null)
            throw new EntityNotFoundException();

        _context.Remove(waybill);
        await _context.SaveChangesAsync(cancellationToken);
    }
}