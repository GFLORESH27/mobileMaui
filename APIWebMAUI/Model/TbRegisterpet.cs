using System;
using System.Collections.Generic;

namespace APIWebMAUI.Model;

public partial class TbRegisterpet
{
    public int IdRegisterpet { get; set; }

    public string? NamePet { get; set; }

    public int? IdService { get; set; }

    public DateTime? DateService { get; set; }

    public string? ActiveRegister { get; set; }

    public virtual TbService? IdServiceNavigation { get; set; }
}
