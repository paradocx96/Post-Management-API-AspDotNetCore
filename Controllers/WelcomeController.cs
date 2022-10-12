using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PostWebAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Welcome()
        {
            dynamic data = new ExpandoObject();
            data.message = "Todo API Server Running!";
            data.active = true;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            return Ok(json);
        }
    }
}