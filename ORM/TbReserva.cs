using System;
using System.Collections.Generic;

namespace Biblioteca.ORM;

public partial class TbReserva
{
    public int Id { get; set; }

    public string DataReserva { get; set; } = null!;

    public int Fkmembro { get; set; }

    public int Fklivro { get; set; }

    public virtual TbLivro FklivroNavigation { get; set; } = null!;

    public virtual TbMembro FkmembroNavigation { get; set; } = null!;
}
