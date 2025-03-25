using System;
using System.Collections.Generic;

namespace Agenda_p.FilmsDB;

public partial class Réalisateur
{
    public int Id { get; set; }

    public string Prénoms { get; set; } = null!;

    public string Noms { get; set; } = null!;

    public string NombreDeFilmsRéalisés { get; set; } = null!;
}
