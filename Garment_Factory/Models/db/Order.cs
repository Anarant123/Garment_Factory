using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class Order
{
    public int Id { get; set; }

    public DateTime Date { get; set; }

    public string Status { get; set; } = null!;

    public string Customer { get; set; } = null!;

    public string? Manager { get; set; }

    public int Price { get; set; }

    public virtual User CustomerNavigation { get; set; } = null!;

    public virtual User? ManagerNavigation { get; set; }

    public virtual ICollection<ProductOrder> ProductOrders { get; } = new List<ProductOrder>();
}
