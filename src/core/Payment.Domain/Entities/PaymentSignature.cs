using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentSignature
{
    public string Id { get; set; } = null!;

    public string? SignValue { get; set; }

    public string? SignAlgo { get; set; }

    public DateTime? SignDate { get; set; }

    public string? SignOwn { get; set; }

    public string? PaymentId { get; set; }

    public virtual Payment? Payment { get; set; }
}
