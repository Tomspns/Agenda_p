using System;
using System.Collections.Generic;

namespace Agenda_p.DAO;

public partial class Contact
{
    public int IdContacts { get; set; }

    public string Prénom { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public DateOnly Naissance { get; set; }

    public string Email { get; set; } = null!;

    public string Numéro { get; set; } = null!;

    public virtual ICollection<Réseaux> Réseauxes { get; set; } = new List<Réseaux>();
}
