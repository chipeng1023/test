using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConsoleApp1.Model
{
    public class Test
    {
        public int? ID { get; set; }
        public string Code { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public IFormFile[] Files { get; set; }
        public static ValueTask<Test> BindAsync(HttpContext context) { return ValueTask.FromResult(new Test()); }
    }
}