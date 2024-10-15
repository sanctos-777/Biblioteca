using System;
using System.Collections.Generic;

namespace Biblioteca.ORM;

public partial class TbEmprestimo
{
    public int Id { get; set; }

    public string DataEmprestimo { get; set; } = null!;

    public string DataDevolucao { get; set; } = null!;

    public int Fkmembro { get; set; }

    public int Fklivro { get; set; }

    public virtual TbLivro FklivroNavigation { get; set; } = null!;

    public virtual TbMembro FkmembroNavigation { get; set; } = null!;
}
