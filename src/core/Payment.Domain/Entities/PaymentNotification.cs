using Payment.Domain.Common;
using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class PaymentNotification: BaseEntity
{
    public Guid? PaymentRefId { get; set; }

    public DateTime? NotiDate { get; set; }

    public decimal? NotiAmount { get; set; }

    public string? NotiContent { get; set; }

    public string? NotiMessage { get; set; }

    public string? NotiSignature { get; set; }

    public Guid? PaymentId { get; set; }

    public Guid? MerchantId { get; set; }

    public string? NotiStatus { get; set; }

    public DateTime? NotiResDate { get; set; }

    public virtual Merchant? Merchant { get; set; }

    public virtual Payment? Payment { get; set; }
}
