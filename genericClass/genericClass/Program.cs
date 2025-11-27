namespace genericClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Repository<Product> repository = new Repository<Product>();
            var product = new Product();
            repository.Add(product);    
        }

        // Constraint valid because if IEntity
        class Product : IEntity 
        { 
            public int Id { get; set; } 
        }
       
    }
}
