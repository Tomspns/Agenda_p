using System;
using System.Collections.Generic;

namespace Agenda_p.DAO;

public partial class Afaire
{
    public int IdAfaire { get; set; }

    public string Titre { get; set; } = null!;

    public string FaitNonFait { get; set; } = null!;
}
