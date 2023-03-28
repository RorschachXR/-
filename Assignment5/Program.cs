using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement
{
    class Program
    {
        static void Main(string[] args)
        {

        }
    }
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public List<OrderDetail> Details { get; set; }

        public Order(int id, string customer)
        {
            Id = id;
            Customer = customer;
            Details = new List<OrderDetail>();
        }

        public void AddDetail(OrderDetail detail)
        {
            if (Details.Contains(detail))
                throw new Exception("Order detail already exists!");
            Details.Add(detail);
        }

        public double TotalAmount
        {
            get => Details.Sum(d => d.Amount);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order && Id == order.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()
        {
            return $"Order{{ Id={Id}, Customer={Customer}, TotalAmount={TotalAmount} }}";
        }
    }

    public class OrderDetail
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }

        public double Amount
        {
            get => Quantity * UnitPrice;
        }

        public OrderDetail(string productName, int quantity, double unitPrice)
        {
            ProductName = productName;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetail detail && ProductName == detail.ProductName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName);
        }

        public override string ToString()
        {
            return $"OrderDetail{{ ProductName={ProductName}, Quantity={Quantity}, UnitPrice={UnitPrice}, Amount={Amount} }}";
        }
    }

    public class OrderService
    {
        private List<Order> orders;

        public OrderService()
        {
            orders = new List<Order>();
        }

        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
                throw new Exception("Order already exists!");
            orders.Add(order);
        }

        public void RemoveOrder(int orderId)
        {
            orders.RemoveAll(o => o.Id == orderId);
        }

        public void UpdateOrder(Order newOrder)
        {
            RemoveOrder(newOrder.Id);
            AddOrder(newOrder);
        }

        public IEnumerable<Order> QueryOrdersByCustomer(string customer)
        {
            var query = from order in orders
                        where order.Customer == customer
                        orderby order.TotalAmount
                        select order;
            return query;
        }

        public IEnumerable<Order> QueryOrdersByProduct(string product)
        {
            var query = from order in orders
                        where order.Details.Exists(d => d.ProductName == product)
                        orderby order.TotalAmount
                        select order;
            return query;
        }

        // other query methods

        public void Sort(Comparison<Order> comparison)
        {
            orders.Sort(comparison);
        }
    }
}