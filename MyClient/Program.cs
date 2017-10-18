using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using SharedClass;

namespace MyClient
{
    class Program
    {
        enum Verbs : int { Get = 1, Put = 2, Post = 3, Delete = 4 };
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Get\n2 - Put\n3 - Post\n4 - Delete");
            Verbs UserInput = (Verbs)Enum.Parse(typeof(Verbs), Console.ReadLine());

            switch (UserInput)
            {
                case Verbs.Get: // get
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:50822/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.GetAsync("/api/myclass").Result;
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                    break;
                case Verbs.Put: // put
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:50822/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var json = "{\"str\":\"one\"}";
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsync("/api/myclass", httpContent).Result;
                        Customer result = response.Content.ReadAsAsync<Customer>().Result;
                    }
                    break;
                case Verbs.Post:  //post
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:50822/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        var json = "{\"str\":\"one\"}";
                        var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                        HttpResponseMessage response = client.PutAsJsonAsync("/api/myclass", httpContent).Result;
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                    break;
                case Verbs.Delete: //delete
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri("http://localhost:50822/");
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                        HttpResponseMessage response = client.DeleteAsync("/api/myclass/one").Result;
                        string result = response.Content.ReadAsStringAsync().Result;
                    }
                    break;
            }
        }
    }
}
