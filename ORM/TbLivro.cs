﻿using System;
using System.Collections.Generic;

namespace Biblioteca.ORM;

public partial class TbLivro
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Autor { get; set; } = null!;

    public int AnoPublicacao { get; set; }

    public int Fkcategoria { get; set; }

    public byte [] Disponibilidade { get; set; }

    public virtual TbCategoria FkcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<TbEmprestimo> TbEmprestimos { get; set; } = new List<TbEmprestimo>();

    public virtual ICollection<TbReserva> TbReservas { get; set; } = new List<TbReserva>();
}
