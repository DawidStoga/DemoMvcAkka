using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace SelfHostedAPI.Controller
{
    [ApiController]
    public class HelloController :ControllerBase
    {
        [Route("Hello")]
        public IActionResult GetHello()
        {
            return Ok("SelfHostedServer");
        }
        [Route("api/get")]
        // GET api/values 
        public IEnumerable<string> Get()
        {

            return new string[] { "value1", "value2" };
        }

        [Route("api/get/{id}")]
        // GET api/values/5 
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values 
        public void Post([FromBody]string value)
        {
        }
        [Route("api/post")]

        // PUT api/values/5 
        public void Put(int id, [FromBody]string value)
        {
        }
        [Route("api/delete")]

        // DELETE api/values/5 
        public void Delete(int id)
        {
        }
    }
    public class MyHub : Hub
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("ConnectedId : " + Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
 
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
