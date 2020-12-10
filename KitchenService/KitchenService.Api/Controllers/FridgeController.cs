using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KitchenService.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace KitchenService.Api.Controllers
{
    [Route("api/appliances/fridge")]
    public class FridgeController : ControllerBase
    {
        private readonly Fridge _fridge;

        public FridgeController(Fridge fridge)
        {
            _fridge = fridge;
        }
  
        
        public IActionResult Get([FromServices] Fridge fridge)
        {
           
            var appliance = new Appliance { ID = fridge.ID, Name = fridge.Name };
            return Ok((Appliance)fridge);
        }

        // GET: /api/appliances/fridge/contents
        [HttpGet("contents")]
        public IActionResult GetContents([FromServices] Fridge fridge)
        {
            return Ok(fridge);
        }




        // POST api/values
        [HttpPost("contents")]
        public IActionResult PostContents(FridgeItem item)
        {
            _fridge.AddItem(item);

            //if (success)
            //{
                return CreatedAtAction(nameof(GetContentsById), new { item.ID}, value: item);
            //}
            //ModelState.AddModelError(nameof(item.ID));
            //return BadRequest();
        }


        // POST api/values

        [HttpGet("contents/{id}")]
        public IActionResult GetContentsById(int id)
        {
            if (_fridge.Contents.FirstOrDefault(x => x.ID == id) is FridgeItem item)
            {
                return Ok(item);
            }
            return NotFound();
        }






        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
