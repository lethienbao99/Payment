using Payment.Domain.Common;
using System;
using System.Collections.Generic;

namespace Payment.Domain.Entities;

public partial class Merchant: BaseEntity
{
    public string Id { get; set; } = null!;

    public string? MerchantName { get; set; }

    public string? MerchantWebLink { get; set; }

    public string? MerchantIpnUrl { get; set; }

    public string? MerchantReturnUrl { get; set; }

    public string? SerectKey { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<PaymentNotification> PaymentNotifications { get; set; } = new List<PaymentNotification>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
