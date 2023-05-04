using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace ASPNetLesson2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        [Route("/")]
        public void Get()
        {
            var context = HttpContext;
            context.Response.Headers.ContentType = "text/html";
            string html = @"<form method=""POST"" action=""https://localhost:7204/home/create"">
                              <label for=""fname"">Id:</label><br>
                              <input type=""number"" id=""fname"" name=""Id"" value=""1""><br>
                              <label for=""lname"">Last name:</label><br>
                              <input type=""text"" id=""lname"" name=""Name1"" value=""Doe""><br><br>
                              <input type=""submit"" value=""Submit"">
                            </form> ";
            context.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(html));
        }
        
        [HttpPost]
        [Route("[action]")]
        public string Create([FromForm] Order order)
        {
            return "this is Create()" + order.Id + order.Name;
        }

        [HttpGet]
        [Route("[action]")]
        public string test([FromBody] Order order)
        {
            return "this is Create()" + order.Id + order.Name;
        }
    }
   public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
