using Microsoft.EntityFrameworkCore;

namespace Company.Delivery.Core;

/// <summary>
/// Отдельный предмет или часть груза,
/// которые перевозятся из одного места в другое.
/// </summary>
[Index(nameof(Number), IsUnique = true)]
public class CargoItem
{
    public Guid Id { get; set; }

    public Guid WaybillId { get; set; }

    public Waybill? Waybill { get; set; }

    //Уникальное в рамках накладной
    public string Number { get; set; } = null!;

    public string Name { get; set; } = null!;
}