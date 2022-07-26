// See https://aka.ms/new-console-template for more information
using Company.client;
using System.Net.Http.Headers;
using System.Net.Http.Json;

HttpClient client = new();
client.BaseAddress = new Uri("https://localhost:7002");
client.DefaultRequestHeaders.Accept.Clear();
client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

HttpResponseMessage response = await client.GetAsync("api/department");
response.EnsureSuccessStatusCode();

if(response.IsSuccessStatusCode)
{
    var departments = await response.Content.ReadFromJsonAsync <IEnumerable<DepartmentDto>>();
    foreach (var department in departments)
    {
        Console.WriteLine(department.Dname);
    }
}
else
{
    Console.WriteLine("No departments at the moment.");
}

Console.ReadLine();