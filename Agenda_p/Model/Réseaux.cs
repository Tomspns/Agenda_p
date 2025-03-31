using System;
using System.Collections.Generic;

namespace Agenda_p.DAO;

public partial class Réseaux
{
    public int IdRéseaux { get; set; }

    public string Instagram { get; set; } = null!;

    public string Facebook { get; set; } = null!;

    public string Snapchat { get; set; } = null!;

    public string TikTok { get; set; } = null!;

    public int ContactsIdContacts { get; set; }

    public virtual Contact ContactsIdContactsNavigation { get; set; } = null!;
}
