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
                    if (number == "1")
                    {
                        for (int i = 1; i < 11; i++)
                        {
                            HttpResponseMessage response = await client.GetAsync($"/posts/{i}");
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
                    }
                    else if (number == "2")
                    {
                        HttpResponseMessage response = await client.GetAsync("/posts/2/comments");
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
                    else if (number == "3")
                    {
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
                    }
                    else
                    {
                        Console.WriteLine("Enter a number between 1 and 3:");
                    }


                }
            } while (!(number == "0"));
        }
    }
}
