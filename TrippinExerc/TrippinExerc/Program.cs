using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TrippinExerc
{
    class Program
    {
        static HttpClient HttpClient = new HttpClient() 
        { BaseAddress = new Uri("https://services.odata.org/TripPinRESTierService/(S(npj54vjthjj0d1nvunlzt1sf))/") };

        static async Task Main(string[] args)
        {
            var contentOfFile = await File.ReadAllTextAsync("users.json");
            IEnumerable<User> users = JsonSerializer.Deserialize<IEnumerable<User>>(contentOfFile);

            foreach (var user in users)
            {
                var result = await HttpClient.GetAsync("People('" + user.UserName + "')");
                if (!result.IsSuccessStatusCode)
                {
                    var newUser = new StringContent(JsonSerializer.Serialize(new NewUser(user)), Encoding.UTF8, "application/json");
                    var addedUsers = await HttpClient.PostAsync("People", newUser);
                    
                    try
                    {
                        addedUsers.EnsureSuccessStatusCode();
                        Console.WriteLine("User:" + user.UserName + " inserted");
                    }
                    catch (Exception e)
                    {   
                        Console.WriteLine(e.GetType().ToString());
                    }
                }
                else
                {
                    Console.WriteLine("User: " + user.UserName + "was found!");
                }
            }
        }
    }
}