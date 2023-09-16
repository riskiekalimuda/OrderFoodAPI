using Azure;
using FoodOrderAPI.Security;
using FoodOrderEntitie.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;

namespace FoodOrderAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        [BasicAuthentication]
        [HttpPost]
        public ActionResult Create(Food food)
        {
            if(Food.InsertFood(food))
                return Ok();
            else
                return BadRequest();    
            
        }
    }
}
