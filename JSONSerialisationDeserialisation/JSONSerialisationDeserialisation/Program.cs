using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace JSONSerialisationDeserialisation
{
    internal class Program
    {
        static  async Task Main(string[] args)
        {

            string url = "https://my-json-server.typicode.com/typicode/demo/posts";
            // an http client to send the get request
            HttpClient httpClient = new HttpClient();

            try
            {
                var httpResponseMessage = await httpClient.GetAsync(url);
                //read the string  from the response's content
                string jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                Console.WriteLine(jsonResponse);

                // Deserialize the json response into a C# array of type Post[]
                var myPost = JsonConvert.DeserializeObject<Post[]>(jsonResponse);

                //print the array objects using a foreach loop
                foreach (var post in myPost)
                {
                    Console.WriteLine($"{ post.Id} { post.Title}");
                }
            }
            catch (Exception e)
            {
                //print the exception message
                Console.WriteLine(e.Message);
            }
            finally
            { 
                httpClient.Dispose();
            }
        }
    }
}
