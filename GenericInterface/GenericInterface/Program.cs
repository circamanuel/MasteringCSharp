using System.Xml.Serialization;

namespace GenericInterface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


    internal interface IRepository<T>
    {
        // Classes that use this Interface need to implement this !
        void Add(T entity);
        void Remove(T entity);
    }

    // Needs to implement IEntity
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class User
    {
        public string Name { get; set; }

        public int Id { get; }
    }

    internal class Repository<T>: IRepository<T>
    {
        public void Add(T entity)
        {

        }

        public void Remove(T entity)
        {
        }
    }
}
