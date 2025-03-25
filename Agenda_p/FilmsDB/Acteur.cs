using System;
using System.Collections.Generic;

namespace Agenda_p.FilmsDB;

public partial class Acteur
{
    public int Id { get; set; }

    public string Prénom { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public int NombreFilms { get; set; }
}
