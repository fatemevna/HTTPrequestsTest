using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string number;
            do
            {
                Console.WriteLine("Enter a number between 1 and 3:");
                 number = Console.ReadLine();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
                    switch (number) {
                        case "1":
                        for (int i = 1; i < 11; i++)
                        {
                            HttpResponseMessage response1 = await client.GetAsync($"/posts/{i}");
                            if (response1.IsSuccessStatusCode)
                            {
                                string responseBody = await response1.Content.ReadAsStringAsync();
                                Console.WriteLine(responseBody);
                            }
                            else
                            {
                                Console.WriteLine($"Error: {response1.StatusCode}");
                            }
                        }
                            break;
                        case "2":
                    
                            HttpResponseMessage response2 = await client.GetAsync("/posts/2/comments");
                        if (response2.IsSuccessStatusCode)
                        {
                            string responseBody = await response2.Content.ReadAsStringAsync();
                            Console.WriteLine(responseBody);
                        }
                        else
                        {
                            Console.WriteLine($"Error: {response2.StatusCode}");
                        }
                            break;
                        case "3":
                    
                        for (int i = 1; i < 11; i++)
                        {
                            HttpResponseMessage response = await client.GetAsync($"/albums/{i}");
                            if (response.IsSuccessStatusCode)
                            {
                                string responseBody = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(responseBody);
                            }
                            else
                            {
                                Console.WriteLine($"Error: {response.StatusCode}");
                            }
                        }
                            break;
                    
                    } 
                


                }
            } while (! (number == "0"));
        }
    }
}
