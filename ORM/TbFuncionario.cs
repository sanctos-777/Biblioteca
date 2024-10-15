using System;
using System.Collections.Generic;

namespace Biblioteca.ORM;

public partial class TbFuncionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int Telefone { get; set; }

    public string Cargo { get; set; } = null!;
}
