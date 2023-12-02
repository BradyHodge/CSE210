using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    private List<Product> products;
    private Customer customer;

    private const decimal ShippingCostUSA = 5m;
    private const decimal ShippingCostInternational = 35m;

    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    public decimal CalculateTotalCost()
    {
        decimal totalCost = products.Sum(product => product.Price * product.Quantity);
        totalCost += customer.Address.IsInUSA() ? ShippingCostUSA : ShippingCostInternational;
        return totalCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing List:\n";
        foreach (var product in products)
        {
            label += $"- {product.Name} (ID: {product.ProductId})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping To:\n{customer.Name}\n{customer.Address.GetFullAddress()}";
    }
}
