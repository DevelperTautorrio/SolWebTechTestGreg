using System;
using System.Collections.Generic;

namespace DOMAIN;

public partial class TechAgendaUserRelation
{
    public int RelationId { get; set; }

    public int SenderId { get; set; }

    public int ReceiverId { get; set; }

    public string RelationshipType { get; set; } = null!;

    public string RelationStatus { get; set; } = null!;

    public DateTime? DateAdded { get; set; }

    public bool? IsFavorite { get; set; }

    public string? Notes { get; set; }

    public virtual TechAgendaUser Receiver { get; set; } = null!;

    public virtual TechAgendaUser Sender { get; set; } = null!;
}
