using Payment.Domain.Common;
using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentSignature: BaseEntity
{
    public string? SignValue { get; set; }

    public string? SignAlgo { get; set; }

    public DateTime? SignDate { get; set; }

    public string? SignOwn { get; set; }

    public Guid? PaymentId { get; set; }
    public bool? IsValid { get; set; }

    public virtual Payment? Payment { get; set; }
}
