using System;
using System.Collections.Generic;

namespace DOMAIN;

public partial class TechAgendaUser
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string PaternalSurname { get; set; } = null!;

    public string? MaternalSurname { get; set; }

    public DateTime? BirthDate { get; set; }

    public string Email { get; set; } = null!;

    public string? Nickname { get; set; }

    public string PasswordHash { get; set; } = null!;

    public string? ProfilePicture { get; set; }

    public DateTime? RegistrationDate { get; set; }

    public DateTime? LastConnection { get; set; }

    public bool? Active { get; set; }

    public string? RecoveryToken { get; set; }

    public DateTime? TokenExpiration { get; set; }

    public string? Phone { get; set; }

    public string? Biography { get; set; }

    public string UserRole { get; set; } = null!;

    public virtual ICollection<TechAgendaExternalContact> TechAgendaExternalContacts { get; set; } = new List<TechAgendaExternalContact>();

    public virtual ICollection<TechAgendaUserRelation> TechAgendaUserRelationReceivers { get; set; } = new List<TechAgendaUserRelation>();

    public virtual ICollection<TechAgendaUserRelation> TechAgendaUserRelationSenders { get; set; } = new List<TechAgendaUserRelation>();
}
