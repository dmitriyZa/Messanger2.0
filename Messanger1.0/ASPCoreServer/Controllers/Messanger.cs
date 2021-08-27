using Messanger1._0;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASPCoreServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Messanger : ControllerBase
    {
        static List<Message> ListofMessages = new List<Message>();
        // GET api/<Message>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            string OutputString = "NotFound";
            if ((id < ListofMessages.Count)&(id>=0)) {
                OutputString = JsonConvert.SerializeObject(ListofMessages[id]);
            }
            Console.WriteLine(String.Format("Запрошено сообщение № {0}:{1}", id, OutputString));
            return OutputString;
        }

        // POST api/<Message>
        [HttpPost]
        public IActionResult Sendmessage([FromBody] Message msg)
        {
            if (msg == null)
            { return BadRequest(); }
            ListofMessages.Add(msg);
            Console.WriteLine(String.Format("Всего сообщений:{0}Посланное Сообщение:{1}",ListofMessages.Count,msg));
            return new OkResult();
        }
              
    }
}
