using FoodOrderEntitie.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodOrderAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        [HttpPost]
        public ActionResult Create(Food food)
        {
            if(Food.InsertFood(food))
                return Ok();
            else
                return BadRequest();    
            
        }
        [HttpDelete("{foodId:int}")]
        public ActionResult Delete(int foodId)
        {
            if (Food.Deletefood(foodId))
                return Ok();
            else
                return BadRequest();
        }
    }
}
