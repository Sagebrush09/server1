using System;
using System.Collections.Generic;

namespace WebApplication2.Model;

public partial class Employee
{
    public int Idemployee { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;

    public string Post { get; set; } = null!;

    public string ContactInfo { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
