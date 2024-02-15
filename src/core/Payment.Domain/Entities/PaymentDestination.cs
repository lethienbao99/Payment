using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentDestination
{
    public string Id { get; set; } = null!;

    public string? DesLogo { get; set; }

    public string? DesShortName { get; set; }

    public string? DesName { get; set; }

    public int? DesSortIndex { get; set; }

    public string? ParentId { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PaymentDestination> InverseParent { get; set; } = new List<PaymentDestination>();

    public virtual PaymentDestination? Parent { get; set; }

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
