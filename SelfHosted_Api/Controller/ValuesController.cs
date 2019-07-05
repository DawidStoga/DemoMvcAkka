using System.Linq;
using Akka.Actor;
using Akka.Message;
using Microsoft.AspNetCore.Mvc;
using SelfHostedAPI.Actor;

namespace SelfHostedAPI.Controller
{
    public class ValuesController: ControllerBase
    {
        [Route("get")]
        [HttpGet]
        public IActionResult Get()
        {
            SystemActors.UserActor.Tell(new GetUsersMsg { } as Msg);
            return Ok();
        }
        [Route("post")]
        [HttpPost]
        public IActionResult Post([FromBody]AddUserMsg user)
        {
            SystemActors.UserActor.Tell(user as Msg);
            return Ok();
        }
        [Route("put")]
        [HttpPut]
        public IActionResult Put([FromBody]UpdateUserMsg user)
        {
            SystemActors.UserActor.Tell(user as Msg);
            return Ok();
        }
        [Route("delete")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            SystemActors.UserActor.Tell(new DeleteUserMsg { Id = id } as Msg);
            return Ok();
        }
    }
}
