using System;
using System.Collections.Generic;

namespace WebApplication2.Model;

public partial class Supplier
{
    public int Idsupplier { get; set; }

    public string Name { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
