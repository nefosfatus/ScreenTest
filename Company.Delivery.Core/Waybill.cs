using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Company.Delivery.Core;

/// <summary>
/// Накладная - это документ, который описывает товары или услуги, которые были переданы от одного лица или организации другому.
/// Она является основным документом для оформления отгрузки товаров или оказания услуг, а также для составления счетов на оплату.
/// </summary>
[Index("Number", IsUnique = true)]
public class Waybill
{
    public Guid Id { get; set; }

    /// <summary>
    /// Уникальное поле
    /// </summary>
    public string Number { get; set; } = null!;

    public DateTime Date { get; set; }

    public ICollection<CargoItem>? Items { get; set; }
}