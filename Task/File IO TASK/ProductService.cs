using System.Xml;

public class ProductService
{
    private const string FilePath = "example.txt";

    public void Create(Product product)
    {
        var products = GetAll();
        products.Add(product);
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(products, Formatting.Indented));
    }

    public Product Get(int id)
    {
        var products = GetAll();
        return products.FirstOrDefault(p => p.Id == id);
    }

    public List<Product> GetAll()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Product>();
        }

        var content = File.ReadAllText(FilePath);
        return JsonConvert.DeserializeObject<List<Product>>(content) ?? new List<Product>();
    }

    public void Delete(int id)
    {
        var products = GetAll();
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            Console.WriteLine("Product not found.");
            return;
        }

        products.Remove(product);
        File.WriteAllText(FilePath, JsonConvert.SerializeObject(products, Formatting.Indented));
        Console.WriteLine("Product deleted successfully.");
    }
}
