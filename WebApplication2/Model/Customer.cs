using System;
using System.Collections.Generic;

namespace WebApplication2.Model;

public partial class Customer
{
    public int Idcustomer { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public virtual ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
