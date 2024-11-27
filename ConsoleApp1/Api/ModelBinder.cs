using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ConsoleApp1.Api
{
    public class ModelBinder<T> where T : class
    {
        public T Value { get; set; }
        public static ValueTask<ModelBinder<T>> BindAsync(HttpContext context)
        {
            return ValueTask.FromResult(new ModelBinder<T> { Value = Activator.CreateInstance<T>() });
        }
    }
}