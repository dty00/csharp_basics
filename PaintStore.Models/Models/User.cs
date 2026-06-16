using System;

namespace PaintStore.Models;

public class User
{
    public int UserID;
    public List<Order> Orders;

    public List<Payment> Payments;
    public User(int id)
    {
        UserID = id;
        Orders= new List<Order>();
        Payments = new List<Payment>();
    }

    public void AddOrder(Order order)
    {
        Orders.Add(order);
    }

    public void AddPaymentHistory(Payment payment)
    {
        Payments.Add(payment);
    }

    public void GetMostExpensiveOrder()
    {
        Console.WriteLine(Orders.OrderByDescending(o => o.GetTotalPrice()).FirstOrDefault());
    }
    public Order? GetLatestOrder()
    {
        return Orders.OrderByDescending(o => o.OrderTime).FirstOrDefault();
    }

    public Payment? GetLowestPayment(){
        return Payments.OrderByDescending(pay => pay.PaymentAmount).LastOrDefault();
    }

    public Payment? GetLatestPayment()
    {
        return Payments.OrderByDescending(pay => pay.PaymentTime).FirstOrDefault();
    }

    public List<Payment>? GetPaymentLargerThanTen()
    {
        return Payments.Where(pay => pay.PaymentAmount>10).ToList();
    }



    
}
