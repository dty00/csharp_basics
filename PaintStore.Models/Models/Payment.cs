using System;
using System.Reflection.Metadata;
using PaintStore.Models.Enums;

namespace PaintStore.Models;

public class Payment
{
    public int PaymentId;
    public PaymentStatus Status;
    public decimal PaymentAmount;
    public PaymentMethod Method;

    public readonly DateTime PaymentTime;

    public Payment(Order order, PaymentMethod method, User user)
    {
        PaymentAmount = order.GetTotalPrice();
        Method = method;
        Status = PaymentStatus.Pending;
        PaymentTime = DateTime.Now;
    }

    public bool CheckPaymentSuccess()
    {
        return Status == PaymentStatus.Success;
    }
    public void MarkAsSuccess()
    {
        Status = PaymentStatus.Success;
    }

    public void MarkAsFailed()
    {
        Status = PaymentStatus.Failed;
    }


    
}
