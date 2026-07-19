using System;
using System.Collections.Generic;

// --- ADDRESS CLASS ---
public class Address
{
    private string _streetAddress;
    private string _city;
    private string _stateOrProvince;
    private string _country;

    public Address(string streetAddress, string city, string stateOrProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateOrProvince = stateOrProvince;
        _country = country;
    }

    public bool IsInNIGERIA()
    {
        return _country.Trim().Equals("NIGERIA", StringComparison.OrdinalIgnoreCase);
    }

    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateOrProvince}\n{_country}";
    }
}

// --- CUSTOMER CLASS ---
public class Customer
{
    private string _name;
    private Address _address;

    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    public string GetName() => _name;

    public bool IsInNIGERIA()
    {
        return _address.IsInNIGERIA();
    }

    public string GetAddressString()
    {
        return _address.GetFullAddress();
    }
}

// --- PRODUCT CLASS ---
public class Product
{
    private string _name;
    private string _productId;
    private double _pricePerUnit;
    private int _quantity;

    public Product(string name, string productId, double pricePerUnit, int quantity)
    {
        _name = name;
        _productId = productId;
        _pricePerUnit = pricePerUnit;
        _quantity = quantity;
    }

    public string GetName() => _name;
    public string GetProductId() => _productId;

    public double GetTotalCost()
    {
        return _pricePerUnit * _quantity;
    }
}

// --- ORDER CLASS ---
public class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double CalculateTotalCost()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }

        double shippingCost = _customer.IsInNIGERIA() ? 5.00 : 35.00;
        return total + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "--- PACKING LABEL ---\n";
        foreach (var product in _products)
        {
            label += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"--- SHIPPING LABEL ---\n{_customer.GetName()}\n{_customer.GetAddressString()}\n";
    }
}

// --- MAIN PROGRAM ENTRY ---
class Program
{
    static void Main(string[] args)
    {
        // Order 1: Customer in Abuja, Nigeria
        Address nigeriaAddress1 = new Address("40 Accra Street", " Wuse Zone 5 Abuja", "FCT", "Nigeria");
        Customer customer1 = new Customer("Kevin Cross Minchakpu", nigeriaAddress1);
        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Wireless Mouse", "M102", 25.50, 2));
        order1.AddProduct(new Product("Mechanical Keyboard", "K840", 79.99, 1));
        order1.AddProduct(new Product("Mouse Pad", "P005", 12.00, 3));

        // Order 2: Customer in Abuja, Nigeria
        Address nigeriaAddress2 = new Address("23 Airport Road", "Abuja", "FCT", "Nigeria");
        Customer customer2 = new Customer("Janet Ojochide Daniel", nigeriaAddress2);
        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("4K Monitor", "MON4K", 299.99, 1));
        order2.AddProduct(new Product("HDMI Cable 6ft", "CBL06", 8.50, 2));

        // Display Results for Order 1
        Console.WriteLine("========================================");
        Console.WriteLine("PROCESSING ORDER 1");
        Console.WriteLine("========================================");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order1.CalculateTotalCost():F2}\n");

        // Display Results for Order 2
        Console.WriteLine("========================================");
        Console.WriteLine("PROCESSING ORDER 2");
        Console.WriteLine("========================================");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine($"Total Cost: ${order2.CalculateTotalCost():F2}\n");
    }
}