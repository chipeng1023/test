using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using ConsoleApp1.Model;

namespace ConsoleApp1.Api
{
    public static class TestApi
    {
        public static void AddApiTest(this WebApplication app)
        {
            var group = app.MapGroup("/api/test").WithTags("System");
            group.MapPost("/save", Save).DisableAntiforgery();
            group.MapPost("/save1", Save1).DisableAntiforgery();
        }

        public static IResult Save(Test test, [NotNull] string flag)
        {
            var v = test;
            return Results.Ok();
        }

        public static IResult Save1(ModelBinder<Test1> test, [NotNull] string flag)
        {
            var v = test.Value;
            return Results.Ok();
        }
    }
}