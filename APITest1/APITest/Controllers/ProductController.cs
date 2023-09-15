using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace APITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            string filePath = "file.txt";

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            string[] fileLines = System.IO.File.ReadAllLines(filePath);
            List<Object> o = new List<Object>();
            foreach (string line in fileLines)
            {
                Object ob = JsonConvert.DeserializeObject<Object>(line);
                o.Add(ob);
            }
            return Ok(o);
        }
        [HttpPost]
        public IActionResult Post(Object o)
        {
            if (o == null)
            {
                return BadRequest("Invalid data.");
            }
            string json = JsonConvert.SerializeObject(o);
            string filePath = "file.txt";
            System.IO.File.AppendAllText(filePath, json + Environment.NewLine);
            return Ok("Object saved to " + filePath);
        }
    }
}