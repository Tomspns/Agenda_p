using System;
using System.Collections.Generic;

namespace Agenda_p.FilmsDB;

public partial class Film
{
    public int Id { get; set; }

    public string Titre { get; set; } = null!;

    public int AnnéeSortie { get; set; }

    public string Durée { get; set; } = null!;

    public string LienDescription { get; set; } = null!;
}
