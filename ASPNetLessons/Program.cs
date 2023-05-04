using System.Text;

namespace ASPNetLessons
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Func<HttpContext, Func<Task>, Task> customMiddleware = CustomMidlleware;
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();


            app.Use(async (context, next) =>
            {
                if (context.Request.Headers["MyKey"] == "Password")
                {
                    await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("This is custom Midlleware"));

                }
                else
                {
                    await next.Invoke();
                }
            });

            app.MapGet("/", async context =>
            {
                StringBuilder content= new StringBuilder();

                foreach (var item in context.Request.Headers)
                {
                    content.AppendLine($"{item.Key}: {item.Value}");
                }
                
                string path = @"htmlpage.html";
                context.Response.ContentType = "text/html";
                await context.Response.SendFileAsync(path); 
            });

            app.MapGet("/about", async context =>
            {
                StringBuilder content = new StringBuilder();

                foreach (var item in context.Request.Headers)
                {
                    content.AppendLine($"{item.Key}: {item.Value}");
                }

                string path = @"C:\Users\User\Desktop\pdp.svg.png";
                await context.Response.SendFileAsync(path);
            });

            app.MapGet("/services", async context =>
            {
                List<string> paths = new List<string>()
                { "Hi", "Privet", "Salom"};

                context.Response.Headers.ContentDisposition = "attachment; filename=my_forest.jpg";
                string path = @"C:\Users\User\Desktop\pdp.svg.png";
                await context.Response.SendFileAsync(path);
            });


            app.Run();
        }

        public static async Task CustomMidlleware(HttpContext context, Func<Task> func)
        {
            if (context.Request.Headers["MyKey"] == "Password")
            {
                await context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes("This is custom Midlleware"));
                //  return Task.CompletedTask;

            }
            else
            {
                await func();
            }
        }


    }


}