using Payment.Domain.Common;
using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class Payment: BaseEntity
{
    public string? PaymentContent { get; set; }
    public string? PaymentContent2 { get; set; }

    public string? PaymentCurrency { get; set; }

    public Guid? PaymentRefId { get; set; }

    public decimal? RequiredAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public DateTime? ExpireDate { get; set; }

    public string? PaymentLanguage { get; set; }

    public Guid? MerchantId { get; set; }

    public Guid? PaymentDestinationId { get; set; }

    public decimal? PaidAmount { get; set; }

    public string? PaymentStatus { get; set; }

    public string? PaymentLastMessage { get; set; }

    public virtual Merchant? Merchant { get; set; }

    public virtual PaymentDestination? PaymentDestination { get; set; }

    public virtual ICollection<PaymentNotification> PaymentNotifications { get; set; } = new List<PaymentNotification>();

    public virtual ICollection<PaymentSignature> PaymentSignatures { get; set; } = new List<PaymentSignature>();

    public virtual ICollection<PaymentTransaction> PaymentTransactions { get; set; } = new List<PaymentTransaction>();
}
