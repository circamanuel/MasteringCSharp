using System.Reflection;

namespace GenericReflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string myName = "Manuel";

            if (myName.GetType() == typeof(string))
            {
                Console.Write(myName);
            }
        }

        internal class ConfigurationManager<T>
        {
            public T LoadedConfiguration { get; set; }
            public ConfigurationManager(T config)
            {
                LoadedConfiguration = config;
            }
        }

        public static void SaveConfig(Type configToSave)
        {
            // Logic
        }
    }
}
