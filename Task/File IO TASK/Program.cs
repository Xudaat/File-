namespace File_IO_TASK
{
   public class Program
    {
        static void Main(string[] args)
        {
            var productService = new ProductService();

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. All Products");
                Console.WriteLine("2. Get Product");
                Console.WriteLine("3. Create Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Exit");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var products = productService.GetAll();
                        if (products.Count == 0)
                        {
                            Console.WriteLine("No products found.");
                        }
                        else
                        {
                            foreach (var product in products)
                            {
                                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, CostPrice: {product.CostPrice}, SalePrice: {product.SalePrice}");
                            }
                        }
                        break;

                    case "2":
                        Console.Write("Enter Product ID: ");
                        if (int.TryParse(Console.ReadLine(), out var id))
                        {
                            var product = productService.Get(id);
                            if (product == null)
                            {
                                Console.WriteLine("Product not found.");
                            }
                            else
                            {
                                Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, CostPrice: {product.CostPrice}, SalePrice: {product.SalePrice}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "3":
                        try
                        {
                            Console.Write("Enter Product Name: ");
                            var name = Console.ReadLine();
                            Console.Write("Enter Cost Price: ");
                            var costPrice = decimal.Parse(Console.ReadLine());
                            Console.Write("Enter Sale Price: ");
                            var salePrice = decimal.Parse(Console.ReadLine());

                            var product = new Product
                            {
                                Name = name,
                                CostPrice = costPrice,
                                SalePrice = salePrice
                            };

                            productService.Create(product);
                            Console.WriteLine("Product created successfully.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Product ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out id))
                        {
                            productService.Delete(id);
                        }
                        else
                        {
                            Console.WriteLine("Invalid ID.");
                        }
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
   }
}

