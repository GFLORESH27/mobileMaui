using System;
using System.Collections.Generic;

namespace APIWebMAUI.Models;

public partial class TbService
{
    public int IdService { get; set; }

    public string? NameService { get; set; }

    public string? ActiveService { get; set; }

    public virtual ICollection<TbRegisterpet> TbRegisterpets { get; set; } = new List<TbRegisterpet>();
}
