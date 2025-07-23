using System;
using System.Collections.Generic;

namespace DOMAIN;

public partial class TechAgendaExternalContact
{
    public int ExtContactId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string PaternalSurname { get; set; } = null!;

    public string? MaternalSurname { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Alias { get; set; }

    public string FriendType { get; set; } = null!;

    public string? Notes { get; set; }

    public virtual ICollection<TechAgendaSocialNetworkContact> TechAgendaSocialNetworkContacts { get; set; } = new List<TechAgendaSocialNetworkContact>();

    public virtual TechAgendaUser User { get; set; } = null!;
}
