using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LuxShare.NETcore3._1Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public dynamic PostFuncDemo([FromForm] string data)
        {

            return data;
        }
    }

    public class Demo
    {
        public string name { get; set; }
        public string reeno { get; set; }
    }
}
