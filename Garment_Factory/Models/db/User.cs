using System;
using System.Collections.Generic;

namespace Garment_Factory.Models.db;

public partial class User
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Role { get; set; } = null!;

    public string? Name { get; set; }

    public virtual ICollection<Order> OrderCustomerNavigations { get; } = new List<Order>();

    public virtual ICollection<Order> OrderManagerNavigations { get; } = new List<Order>();
}
