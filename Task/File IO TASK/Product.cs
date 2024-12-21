using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Product
{
    private static int _counter = 0;

    public int Id { get; private set; }
    public string Name { get; set; }
    public decimal CostPrice { get; set; }

    private decimal _salePrice;
    public decimal SalePrice
    {
        get => _salePrice;
        set
        {
            if (value < CostPrice)
            {
                throw new ArgumentException("SalePrice cannot be less than CostPrice.");
            }
            _salePrice = value;
        }
    }

    public Product()
    {
        Id = ++_counter;
    }
}
