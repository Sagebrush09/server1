using System;
using System.Collections.Generic;

namespace WebApplication2.Model;

public partial class Product
{
    public int Idproduct { get; set; }

    public string Name { get; set; } = null!;

    public string Availability { get; set; } = null!;

    public int Idtype { get; set; }

    public string Сost { get; set; } = null!;

    public int Idemployees { get; set; }

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public virtual Employee IdemployeesNavigation { get; set; } = null!;
}
