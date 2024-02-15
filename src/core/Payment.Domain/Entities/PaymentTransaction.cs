using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentTransaction
{
    public string Id { get; set; } = null!;

    public string? TranMessage { get; set; }

    public string? TranPayload { get; set; }

    public string? TranStatus { get; set; }

    public decimal? TranAmount { get; set; }

    public DateTime? TranDate { get; set; }

    public string? PaymentId { get; set; }

    public virtual Payment? Payment { get; set; }
}
