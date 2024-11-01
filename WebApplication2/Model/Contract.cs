using System;
using System.Collections.Generic;

namespace WebApplication2.Model;

public partial class Contract
{
    public int Idcontract { get; set; }

    public DateOnly DateStart { get; set; }

    public DateOnly DateFinish { get; set; }

    public int Idproduct { get; set; }

    public int Idcustomers { get; set; }

    public int Idsupplier { get; set; }

    public virtual Customer IdcustomersNavigation { get; set; } = null!;

    public virtual Product IdproductNavigation { get; set; } = null!;

    public virtual Supplier IdsupplierNavigation { get; set; } = null!;
}
