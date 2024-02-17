using Payment.Domain.Common;
using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentTransaction: BaseEntity
{
    public string? TranMessage { get; set; }

    public string? TranPayload { get; set; }

    public string? TranStatus { get; set; }

    public decimal? TranAmount { get; set; }

    public DateTime? TranDate { get; set; }

    public Guid? PaymentId { get; set; }
    public Guid? TranRefId { get; set; }

    public virtual Payment? Payment { get; set; }
}
