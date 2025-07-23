using System;
using System.Collections.Generic;

namespace DOMAIN;

public partial class TechAgendaSocialNetworkContact
{
    public int SocialNetworkContactId { get; set; }

    public int ExternalContactId { get; set; }

    public string SocialNetworkName { get; set; } = null!;

    public string ProfileUrl { get; set; } = null!;

    public string? SocialDescription { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? LastUpdatedDate { get; set; }

    public virtual TechAgendaExternalContact ExternalContact { get; set; } = null!;
}
