using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace ConsoleApp1.Model
{
    public class Test1
    {
        public int? ID { get; set; }
        public string Code { get; set; }
        [JsonRequired]
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public IFormFile[] Files { get; set; }
    }
}