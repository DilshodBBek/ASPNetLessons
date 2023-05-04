namespace ASPNetLesson2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.MapControllers();

            //app.MapGet("/", () =>
            //{
            //    return app.Configuration.GetValue<string>("Mykey");
            //});
            app.Run();
        }
    }
}