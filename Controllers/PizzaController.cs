using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PappaPizza.Models;
using PappaPizza.Services;

namespace PappaPizza.Controllers
{
    //Controllers are classes that handle incoming HTTP requests
    //Controllers are where we define our endpoints

    //The HTTP requests are
    //    GET
    //    POST
    //    PUT
    //    DELETE
    //Controllers them respond messages like--- 200OK(perfect), 400(invalid request) ,500(server error)



    //Rout is the rout its the URI of the controller the [controller] is replaced with the controller name and serve as a link for the functio in the controller
    //"api/Pizza" as path
    [Route("api/[controller]")]


    //[ApiController] enables opioniated behaviours that make it easier to build web APIs.Which includes parameter source inference,attribute routing as a requirement, and model
    // validation error-handling enhancements
    //also used to pass a value from the URl to the method as shown in line 38;

    [ApiController]
    
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);
            if(pizza == null) 
                return NotFound();
            return Ok(pizza);
        }

        [HttpPost]
        public ActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Create), new { id = pizza.Id}, pizza);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null) return NotFound();

            PizzaService.Delete(pizza);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Pizza pizza, int id)
        {
            if(id != pizza.Id)
                return BadRequest();

            var Existingpizza = PizzaService.Get(id);

            if (Existingpizza is null) return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        
    }

    
}
