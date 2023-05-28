using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using MongoDB.Bson;
using MongoDB.Driver;
namespace GoogleBooksApi
{
    class Program
    {
        static void Main(string[] args)
        {
            Constants.mongoClient = new MongoClient("xxx");
            Constants.database = Constants.mongoClient.GetDatabase("TelegramBot");
            Constants.collection = Constants.database.GetCollection<BsonDocument>("xxx");





            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // äîáàâëåíèå Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                // çàäàíèå ïàðàìåòðîâ Swagger
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "My API",
                    Version = "v1"
                });
            });

            var app = builder.Build();

            // íàñòðîéêà Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();

        }
    }
}
